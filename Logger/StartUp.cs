using Logger.Core;
using Logger.Factories;
using Logger.Models.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Logger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int AppndrCount = int.Parse(Console.ReadLine());
            ICollection<IAppender> appenders = new List<IAppender>();
            AppenderFactory appenderFactory = new AppenderFactory();
            ReadAppenderData(AppndrCount, appenders,appenderFactory);
            ILogger logger = new Logger.Models.Layouts.Logger(appenders);

            Engine engine = new Engine(logger);
            engine.Run();

        }

        private static void ReadAppenderData(int appndrCount, ICollection<IAppender> appenders,AppenderFactory appenderFactory)
        {

            for (int i = 0; i < appndrCount; i++)
            { 
                string[] appendersInfo = Console.ReadLine()
                    .Split(" ")
                    .ToArray();

                string appenderType = appendersInfo[0];
                string layoutType = appendersInfo[1];
                string levelStr = "INFO";
                if (appendersInfo.Length==3)
                {
                    levelStr = appendersInfo[2];
                }
                try
                {
                   IAppender appender = appenderFactory.GetAppender(appenderType, layoutType, levelStr);
                    appenders.Add(appender);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }
    }
}
