namespace Chat.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System.Collections.Generic;

    public class User
    {
        public User()
        {
            this.Id = ObjectId.GenerateNewId().ToString();
            this.messages = new HashSet<Message>();
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        private ICollection<Message> messages;

        public ICollection<Message> Messages
        {
            get { return messages; }
            set { messages = value; }
        }
    }
}