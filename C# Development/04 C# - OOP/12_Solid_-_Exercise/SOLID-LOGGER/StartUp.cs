using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using SOLID_LOGGER.Core;
using SOLID_LOGGER.Factories;
using SOLID_LOGGER.Models;
using SOLID_LOGGER.Models.Contracts;

namespace SOLID_LOGGER
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int appendersCount = int.Parse(Console.ReadLine());

            ICollection<IAppender> appenders = new List<IAppender>();

            AppendantFactory appendantFactory = new AppendantFactory();

            ReadAppendersData(appendersCount, appenders, appendantFactory);

            ILogger logger = new Logger(appenders);

            Engine engine = new Engine(logger);
            engine.Run();
            
        }

        private static void ReadAppendersData(int appendersCount, ICollection<IAppender> appenders, AppendantFactory appendantFactory)
        {
            for (int i = 0; i < appendersCount; i++)
            {
                string[] appendersInfo = Console.ReadLine().Split().ToArray();

                string appenderType = appendersInfo[0];
                string layputType = appendersInfo[1];
                string levelStr = "INFO";

                if (appendersInfo.Length == 3)
                {
                    levelStr = appendersInfo[2];
                }


                try
                {
                    IAppender appender = appendantFactory.GetAppender(appenderType, layputType, levelStr);
                    appenders.Add(appender);
                }
                catch (Exception)
                {
                    //Ouput not needed
                    //Console.WriteLine(e.Message);
                    continue;

                }

            }
        }
    }
}
