using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Models;
using MongoDB.Driver.Builders;
using Chat.Common;

namespace Chat.Client
{
    public class Program
    {
        private const string connectionString = "mongodb://127.0.0.1";
        static void Main(string[] args)
        {
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("chat");

            database.DropCollection("messages");
            database.DropCollection("users");
            
            ChatSystem.Register("Ivancho", "ivan11", database);
            Console.WriteLine("added Ivancho");
            ChatSystem.Register("Mariika", "mimi12", database);
            Console.WriteLine("added Mariika");

            var ivnacho = ChatSystem.Login("Ivancho", "ivan11", database);
            var mariika = ChatSystem.Login("Mariika", "mimi12", database);

            ChatSystem.Post(ivnacho, "Hello!", database);
            ChatSystem.Post(mariika, "Hello!", database);
            ChatSystem.Post(ivnacho, "I am Ivancho!", database);
            ChatSystem.Post(mariika, "I am Mariika, nice to meet you!", database);      

            DateTime today = DateTime.Now.AddDays(1);
            DateTime yesterday = DateTime.Now.AddDays(-1);
            foreach (var post in ChatSystem.GetPosts(yesterday, today, database))
            {
                Console.WriteLine("{0} said: {1}\n at {2}",post.UserName, post.Message, post.Date);
                Console.WriteLine();
            }

        }


    }
}
