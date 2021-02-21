using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.MovieRationg
{
    class Program
    {
        static void Main(string[] args)
        {
            int movieCount = int.Parse(Console.ReadLine());
            string name;
            double rating;
            double minRating = double.MaxValue;
            double maxRating = double.MinValue;
            string minRatingName = string.Empty;
            string maxRatingName = string.Empty;
            double counter = 0;
            double sum = 0;

            for (int i = 0; i < movieCount; i++)
            {
                name = Console.ReadLine();
                rating = double.Parse(Console.ReadLine());

                if (rating > maxRating)
                {
                    maxRating = rating;
                    maxRatingName = name;
                   
                }
                else if (rating < minRating)
                {
                    minRating = rating;
                    minRatingName = name;
                    
                }
                counter += rating;
            }
            sum = counter / movieCount;
            Console.WriteLine($"{maxRatingName} is with highest rating: {maxRating:f1}");
            Console.WriteLine($"{minRatingName} is with lowest rating: {minRating:f1}");
            Console.WriteLine($"Average rating: {sum:f1}");
        }
    }
}
