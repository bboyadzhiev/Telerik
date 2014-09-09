namespace Chat.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System;

    public class Message
    {
        public Message()
        {
            this.Id = ObjectId.GenerateNewId().ToString();
        }
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }
    }
}