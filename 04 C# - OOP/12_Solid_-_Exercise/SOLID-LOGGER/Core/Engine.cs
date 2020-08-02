using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOLID_LOGGER.Factories;
using SOLID_LOGGER.Models.Contracts;

namespace SOLID_LOGGER.Core
{
    public class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;


        public Engine(ILogger logger)
        {
            this.logger = logger;
            errorFactory = new ErrorFactory();
        }

        public void Run()
        {
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] errorArgs = command.Split('|').ToArray();
                string level = errorArgs[0];
                string date = errorArgs[1];
                string message = errorArgs[2];
                IError error;

                try
                {
                    error = this.errorFactory.GetError(date, level, message);
                    this.logger.Log(error);
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e.Message));

                }

                command = Console.ReadLine();

            }

            Console.WriteLine(this.logger.ToString());
        }
    }
}
