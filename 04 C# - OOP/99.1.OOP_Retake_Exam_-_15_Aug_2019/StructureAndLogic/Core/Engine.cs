using SpaceStation.Core.Contracts;
using SpaceStation.IO;
using SpaceStation.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private Controller controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
        }
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddAstronaut")
                    {
                        string astrType = input[1];
                        string astrName = input[2];

                        writer.WriteLine(this.controller.AddAstronaut(astrType,astrName));
                    }
                    else if (input[0] == "AddPlanet")
                    {
                        string planetName = input[1];
                        string[] items = input.Skip(2).ToArray();

                        writer.WriteLine(this.controller.AddPlanet(planetName,items));
                    }
                    else if (input[0] == "RetireAstronaut")
                    {
                        string astrName = input[1];

                        writer.WriteLine(this.controller.RetireAstronaut(astrName));
                    }
                    else if (input[0] == "ExplorePlanet")
                    {
                        string planetName = input[1];

                        writer.WriteLine(this.controller.ExplorePlanet(planetName));
                    }
                    else if(input[0] == "Report")
                    {
                        writer.WriteLine(this.controller.Report());
                    }
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
