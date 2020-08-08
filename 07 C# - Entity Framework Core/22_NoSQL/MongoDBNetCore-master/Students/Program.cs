using System;
using System.Linq;
using MongoDB.Data.Attributes;
using MongoDB.Data.Documents;
using MongoDB.Data.Repository;
using MongoDB.Data.Settings;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
         IMongoDbSettings settings = new MongoDbSettings();
         settings.ConnectionString = "mongodb://127.0.0.1:27017";
         settings.DatabaseName = "Students";

         IMongoRepository<Student> repository = new MongoRepository<Student>(settings);
         int option = 0;

             do
             {
                 Console.WriteLine("Choose Option 1 (Create), 2 (list),3");
                 option = int.Parse(Console.ReadLine());

                 if (option == 1)
                 {
                     Console.WriteLine("Enter student name:");
                     string name = Console.ReadLine();
                     Console.WriteLine("Enter student age:");
                     int age = int.Parse(Console.ReadLine());
                     Student student = new Student()
                     {
                         Name = name,
                         Age = age
                     };

                     repository.InsertOne(student);
                 }
                 else if (option==2)
                 {
                     ListAll(repository);
                 }
             } while (option < 0);

        }

        private static void ListAll(IMongoRepository<Student> repository)
        {
            var allStudents = repository.AsQueryable().ToList();
            foreach (var student in allStudents)
            {
                Console.WriteLine(student.Name + " " + student.Age);
            }
        }
    }

    [BsonCollection("Students")]
    public class Student : Document
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
