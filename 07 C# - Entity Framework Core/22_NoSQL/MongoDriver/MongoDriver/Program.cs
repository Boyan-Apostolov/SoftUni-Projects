using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MongoClient("mongodb://127.0.0.1:27017");
            var database = client.GetDatabase("Softuni");
            var collection = database.GetCollection<BsonDocument>("Students");
            var student = new BsonDocument()
            {
                { "name", "peshoStudent"}
            };

            collection.InsertOne(student);

            var allStudents = collection.Find<BsonDocument>(new BsonDocument()).ToList();

            foreach (var item in allStudents)
            {
                Console.WriteLine(item); 
            }
        }
    }

}
