using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using BullsAndCows.Data;
using BullsAndCows.Models;
using BullsAndCows.WebApi.DataModels;
using Microsoft.AspNet.Identity;

namespace BullsAndCows.WebApi.Controllers
{

    public class GamesController : ApiController //: BaseApiController
    {
        private IBullsAndCowsData data;

        public GamesController(IBullsAndCowsData data)
        //   :base(data)
        {
            this.data = data;
        }

        public GamesController()
        {
            this.data = new BullsAndCowsData();
        }

        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult Get() // GET	/api/games
        {
            var publicGames = this.GetAllOrdered()
                .Take(10)
                .Select(GameDataModel.FromGame).ToList();
            return Ok(publicGames);
        }


        [HttpGet]
        public IHttpActionResult Get(int page)   // GET	/api/games?page=P
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var userGames = this.GetAllForUserOrdered()
                .Skip(10 * page)
                .Take(10)
                .Select(GameDataModel.FromGame).ToList();
                return Ok(userGames);
            }                                 

                var publicGames = this.GetAllOrdered()
                    .Skip(10 * page)
                    .Take(10)
                    .Select(GameDataModel.FromGame).ToList();
                return Ok(publicGames);
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult GetById(int id) // GET  http://localhost:XXXXX/api/games/{ID}  (authorized)
        {
            var playerId = this.User.Identity.GetUserId();
            var player = this.data.Players.SearchFor(p => p.Id == playerId).FirstOrDefault();

            GameDetailsDataModel gameDetails = this.data.Games.All()
                .Where(g => (g.RedPlayerId == playerId || g.BluePlayerId == playerId) && g.Id == id)
                .Select(GameDetailsDataModel.FromGame)
                .FirstOrDefault();

            if (gameDetails == null)
            {
                return NotFound();
            }

            gameDetails.YourNumber = player.YourNumber;
            gameDetails.YourColor = player.YourColor;

            List<GuessModel> opponentGuesses = new List<GuessModel>();
            if (gameDetails.Red == playerId)
            {

               opponentGuesses = this.data.Guesses.All().Where(g => g.GameId == id && g.Game.BluePlayerId == playerId).Select(GuessModel.FromGuess).ToList();
            }
            else
            {
                opponentGuesses = this.data.Guesses.All().Where(g => g.GameId == id && g.Game.RedPlayerId == playerId).Select(GuessModel.FromGuess).ToList();
            }


            var yourGuesses = this.data.Guesses.All().Where(g => g.GameId == id && g.PlayerId == playerId).Select(GuessModel.FromGuess);

            foreach (var guess in yourGuesses)
            {
                gameDetails.YourGuesses.Add(guess);
            }

            foreach (var guess in opponentGuesses)
            {
                gameDetails.OpponentGuesses.Add(guess);
            }

            return Ok(gameDetails);
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Post(NewGameDataModel newGame)   // POST	/api/games    // Create Game
        {
            var userId = this.User.Identity.GetUserId();
            var user = this.data.Players.SearchFor(p => p.Id == userId).FirstOrDefault(); //.Find(this.User);
            var game = new Game
            {
                Name = newGame.name,
                RedPlayerId = userId,
                RedPlayer = user,
                GameState = GameStates.WaitingForOpponent,
                DateCreated = DateTime.Now
            };

            user.YourNumber = int.Parse(newGame.number);
            user.Games.Add(game);
            user.YourColor = Colors.red;

            this.data.Games.Add(game);
            this.data.SaveChanges();

            var newGameDataModel = this.data.Games.SearchFor(x => x.Id == game.Id).Select(GameDataModel.FromGame).FirstOrDefault();
            return Ok(newGameDataModel);

        }


        [HttpPut]
        [Authorize]
        public IHttpActionResult Put(int id, [FromBody]string numberString) // PUT	/api/games/{id}  - JOIN GAME
        {
            var userId = this.User.Identity.GetUserId();
            var bluePlayer = this.data.Players.SearchFor(p => p.Id == userId).FirstOrDefault();
            var game = this.data.Games.SearchFor(x => x.Id == id).FirstOrDefault();
            if (game.RedPlayerId == userId)
            {
                return Ok("You are in this game already as Red Player");
            }

            bluePlayer.YourNumber = int.Parse(numberString);
            bluePlayer.YourColor = Colors.blue;

            var redPlayer = game.RedPlayer;
            redPlayer.Notifications.Add(new Notification
            {
                PlayerId = redPlayer.Id,
                Game = game,
                Message = bluePlayer.UserName + " joined your game " + '\\' + game.Name + '\\',
                DateCreated = DateTime.Now,
                Type = NotificationTypes.GameJoined,
                State = NotificationStates.Unread,
                GameId = game.Id
            });


            Random rnd = new Random();
            if (rnd.Next(0, 2) == 0)
            {
                game.PlayerInTurn = redPlayer;
                game.PlayerInTurnId = redPlayer.Id;
                redPlayer.Notifications.Add(new Notification
                {
                    PlayerId = redPlayer.Id,
                    Game = game,
                    Message = "It is your turn in game " + '\\' + game.Name + '\\',
                    DateCreated = DateTime.Now,
                    Type = NotificationTypes.YourTurn,
                    State = NotificationStates.Unread,
                    GameId = game.Id
                });
            }
            else
            {
                game.PlayerInTurn = bluePlayer;
                game.PlayerInTurnId = bluePlayer.Id;
                bluePlayer.Notifications.Add(new Notification
                {
                    PlayerId = bluePlayer.Id,
                    Game = game,
                    Message = "It is your turn in game " + '\\' + game.Name + '\\',
                    DateCreated = DateTime.Now,
                    Type = NotificationTypes.YourTurn,
                    State = NotificationStates.Unread,
                    GameId = game.Id
                });
            }

            this.data.SaveChanges();

            var result = new { result = "You joined game " + '\\' + game.Name + '\\' };
            return Ok(result);

        }


        private IQueryable<Game> GetAllOrdered()
        {
            return this.data.Games.All()
                .OrderBy(g => g.GameState)
                .ThenBy(a => a.DateCreated)
                .ThenBy(p => p.RedPlayer.UserName);
        }

        private IQueryable<Game> GetAllForUserOrdered()
        {
            var user = this.User.Identity;
            var userId = user.GetUserId();
            return this.data.Games.All()
                .Where(g => g.RedPlayerId == userId && g.BluePlayerId == String.Empty)
                .OrderBy(g => g.GameState)
                .ThenBy(a => a.DateCreated)
                .ThenBy(p => p.RedPlayer.UserName);
        }


    }
}
