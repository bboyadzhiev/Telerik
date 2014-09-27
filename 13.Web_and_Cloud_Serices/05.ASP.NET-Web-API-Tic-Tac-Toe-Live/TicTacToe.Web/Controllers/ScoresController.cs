namespace TicTacToe.Web.Controllers
{
    using System.Linq;
    using System.Collections.Generic;
    using System.Web.Http;

    using TicTacToe.Data;
    using TicTacToe.GameLogic;
    using TicTacToe.Web.Infrastructure;
    using TicTacToe.Models;

    public class ScoresController : BaseApiController
    {
        private IUserIdProvider userIdProvider;

        public ScoresController(
            ITicTacToeData data,
            IGameResultValidator resultValidator,
            IUserIdProvider userIdProvider)
            : base(data)
        {
            this.userIdProvider = userIdProvider;
        }

        [AllowAnonymous]
        public IHttpActionResult Get()
        {
            var scores = this.data.Users.All().OrderByDescending(CalculateRank).Select(u => new
            {
                User = u.Email,
                Score = CalculateRank(u),
                Wins = u.WinsCount,
                Losses = u.LossesCount
            });

            return Ok(scores);
        }

        private static int CalculateRank(User user)
        {
            return  user.WinsCount + user.LossesCount;
        }
    }
}