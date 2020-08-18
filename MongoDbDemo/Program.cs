using MongoDbDemo.Entities;
using System;
using System.Collections.Generic;

namespace MongoDbDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            static void Insert()
            {
                MongoCRUD db = new MongoCRUD("Users");
                User userToInsert = new User("Luiz", 17, true);
                Pet pet = new Pet("Pipoca", "Dog");
                userToInsert.Pet = pet;
                db.Insert<User>("Users", userToInsert);
            }

            static void GetAll()
            {
                MongoCRUD db = new MongoCRUD("Users");
                List<User> users = db.GetAll<User>("Users");
            }

            static void Get()
            {
                MongoCRUD db = new MongoCRUD("Users");
                string id = Console.ReadLine();
                User userFound = db.Get<User>("Users", new Guid(id));
            }

            static void Update()
            {
                MongoCRUD db = new MongoCRUD("Users");
                string id = Console.ReadLine();
                db.Update<User>("Users", new Guid(id), new User("Luiz", 17, true));
            }

            static void Delete()
            {
                MongoCRUD db = new MongoCRUD("Users");
                string id = Console.ReadLine();
                db.Delete<User>("Users", new Guid(id));
            }

            Console.ReadLine();
        }
    }


}
