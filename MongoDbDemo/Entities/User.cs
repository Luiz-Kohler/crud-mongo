using MongoDB.Bson.Serialization.Attributes;
using MongoDbDemo.Entities;
using System;

namespace MongoDbDemo
{
    public class User
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsBrazilian { get; set; }
        public Pet Pet { get; set; }

        public User(string name, int age, bool isBrazilian)
        {
            Name = name;
            Age = age;
            IsBrazilian = isBrazilian;
        }

        public User() { }
    }
}
