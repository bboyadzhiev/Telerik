using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Redis_Demos
{
    public class Log 
    {
        public ICollection<string> Todos { get; set; }
        public string name;
        public Log()
        {
            this.Todos = new HashSet<string>();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            

            var redis = new RedisClient();
            var redisLogs = redis.As<Log>();
            //var log = new Log();
            //log.name = "nema";
            //log.Todos.Add("todo new");
            //
            
            redisLogs.Store(new Log
            {
                name ="adasd"
            });
            //redisLogs.GetAll()
            //    .Print();

            var logs = redis.As<Log>();
            var todos = logs.GetAll();

            foreach (var todo in todos)
            {
                Console.WriteLine("|"+todo.name);
            }
            Console.WriteLine();

            redisLogs.GetAll().Print();
        }
    }
}
