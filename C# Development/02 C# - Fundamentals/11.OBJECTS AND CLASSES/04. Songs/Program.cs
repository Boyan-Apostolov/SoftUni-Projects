using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;

namespace _04._Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;

            var songList = new List<Song>();

            string command = null; //
            string typeFilter = null; //

            switch (command)
            {
                case "all":                    // LOOK IN LAB FOR SOLUTION
                    Console.WriteLine(songList[songList.Count-1].Name);
                    break;
                default:
                    foreach (var song in songList)
                    {
                        if (song.Type == typeFilter)
                        {
                            Console.WriteLine(song.Name);
                        }
                    }
                    break;
            }

        }
    }
}
