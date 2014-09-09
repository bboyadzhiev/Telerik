using Chat.Models;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Chat.Common
{
    public static class ChatSystem
    {
        public static UserSession Login(string userName, string password, MongoDatabase db)
        {
            var users = db.GetCollection<User>("users");

            var userQuery = Query<User>.Where(u => u.UserName == userName && u.Password == password);
            var user = users.Find(userQuery).FirstOrDefault();
            if (user != null)
            {
                return new UserSession(user);
            }
            throw new Exception("Login failed!");
        }

        public static void Logout(UserSession session)
        {
            session.Invalidate();
        }

        public static bool Register(string userName, string password, MongoDatabase db)
        {
            var users = db.GetCollection<User>("users");
            var userQuery = Query<User>.Where(u => u.UserName == userName && u.Password == password);
            var user = users.Find(userQuery).FirstOrDefault();
            if (user != null)
            {
                return false;
            }

            var newUser = new User { UserName = userName, Password = password };
            var result = users.Insert(newUser);
            if (result.Ok)
            {
                return true;
            }
            return false;
        }

        public static bool Post(UserSession session, string message, MongoDatabase db)
        {
            if (message.Length == 0)
            {
                throw new ArgumentException("Message cannot be 0 length!");
            }
            if (session.Expired)
            {
                throw new Exception("Your session has expired!");
            }
            var messages = db.GetCollection<Message>("messages");
            var newMessage = new Message { Text = message, Date = DateTime.Now, UserId = session.User.Id };
            var result = messages.Insert(newMessage);
            if (result.Ok)
            {
                session.LastActivityDate = DateTime.Now;
                return true;
            }
            return false;
        }

        public static IList<Post> GetPosts(DateTime startDate, DateTime endDate, MongoDatabase db)
        {

            var dated = Query<Message>.Where(message => message.Date >= startDate && message.Date <= endDate);

            var messagesCollection = db.GetCollection<Message>("messages");
            var users = db.GetCollection<User>("users");

            var messages = messagesCollection.Find(dated);
            var result = new List<Post>();

            foreach (var message in messages)
            {
                var userQuery = Query<User>.Where(u => u.Id == message.UserId);
                var user = users.Find(userQuery).FirstOrDefault();

                var post = new Post { Message = message.Text, UserName = user.UserName, Date = message.Date };
                result.Add(post);
            }
            return result;
        }

        public static IList<Post> GetAllPosts( MongoDatabase db)
        {

            var messagesCollection = db.GetCollection<Message>("messages");
            var users = db.GetCollection<User>("users");

            var messages = messagesCollection.FindAll();
            var result = new List<Post>();

            foreach (var message in messages)
            {
                var userQuery = Query<User>.Where(u => u.Id == message.UserId);
                var user = users.Find(userQuery).FirstOrDefault();

                var post = new Post { Message = message.Text, UserName = user.UserName, Date = message.Date };
                result.Add(post);
            }
            return result;
        }
    }
}
