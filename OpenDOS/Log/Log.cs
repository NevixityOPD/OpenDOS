using System;
using System.IO;

namespace OpenDOS.Log
{
    public static class Log
    {
        public static void ShowLog(string title, LogWarningLevel warninglevel, LogWritter writter)
        {
            switch (warninglevel)
            {
                case LogWarningLevel.Information:
                    switch (writter)
                    {
                        case LogWritter.System:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("[Info](System) ");
                            Console.ResetColor();
                            Console.WriteLine(title);
                            Kernel.logList.Add(new LogMessage()
                            {
                                messageString = $"[Info : {DateTime.Now.ToShortTimeString()}](System) {title}",
                                warningLevel = LogWarningLevel.Information,
                            });
                            break;
                        case LogWritter.User:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("[Info](User) ");
                            Console.ResetColor();
                            Console.WriteLine(title);
                            Kernel.logList.Add(new LogMessage()
                            {
                                messageString = $"[Info : {DateTime.Now.ToShortTimeString()}](User) {title}",
                                warningLevel = LogWarningLevel.Information,
                            });
                            break;
                    }
                    break;
                case LogWarningLevel.Warning:
                    switch (writter)
                    {
                        case LogWritter.System:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("[Warning](System) ");
                            Console.ResetColor();
                            Console.WriteLine(title);
                            Kernel.logList.Add(new LogMessage()
                            {
                                messageString = $"[Warning : {DateTime.Now.ToShortTimeString()}](System) {title}",
                                warningLevel = LogWarningLevel.Warning,
                            });
                            break;
                        case LogWritter.User:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("[Warning](User) ");
                            Console.ResetColor();
                            Console.WriteLine(title);
                            Kernel.logList.Add(new LogMessage()
                            {
                                messageString = $"[Warning : {DateTime.Now.ToShortTimeString()}](User) {title}",
                                warningLevel = LogWarningLevel.Warning,
                            });
                            break;
                    }
                    break;
                case LogWarningLevel.Error:
                    switch (writter)
                    {
                        case LogWritter.System:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("[Error](System) ");
                            Console.ResetColor();
                            Console.WriteLine(title);
                            Kernel.logList.Add(new LogMessage()
                            {
                                messageString = $"[Error : {DateTime.Now.ToShortTimeString()}](System) {title}",
                                warningLevel = LogWarningLevel.Error,
                            });
                            break;
                        case LogWritter.User:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("[Error](User) ");
                            Console.ResetColor();
                            Console.WriteLine(title);
                            Kernel.logList.Add(new LogMessage()
                            {
                                messageString = $"[Error : {DateTime.Now.ToShortTimeString()}](User) {title}",
                                warningLevel = LogWarningLevel.Error,
                            });
                            break;
                    }
                    break;
            }
        }

        public static void SilentLog(string title, LogWarningLevel warninglevel)
        {
            switch (warninglevel)
            {
                case LogWarningLevel.Information:
                    Kernel.logList.Add(new LogMessage()
                    {
                        messageString = $"[Info : {DateTime.Now.ToShortTimeString()}] {title}",
                        warningLevel = LogWarningLevel.Information,
                    });
                    break;
                case LogWarningLevel.Warning:
                    Kernel.logList.Add(new LogMessage()
                    {
                        messageString = $"[Warning : {DateTime.Now.ToShortTimeString()}] {title}",
                        warningLevel = LogWarningLevel.Warning,
                    });
                    break;
                case LogWarningLevel.Error:
                    Kernel.logList.Add(new LogMessage()
                    {
                        messageString = $"[Error : {DateTime.Now.ToShortTimeString()}] {title}",
                        warningLevel = LogWarningLevel.Error,
                    });
                    break;
            }
        }

        public static void SaveLog()
        {
            ShowLog("Saving all logs recorded, This may take some times", LogWarningLevel.Information, LogWritter.System);

            File.CreateText($@"0:\System\Log\{DateTime.Now.ToShortDateString().Replace('/', '-')}.syslog");
            File.WriteAllLines($@"0:\System\Log\{DateTime.Now.ToShortDateString().Replace('/', '-')}.syslog", new string[]
            {
                $"Date : {DateTime.Now.ToShortDateString()}",
                "OpenDOS System Log",
                "",
                "",
            });

            for (int i = 0; i < Kernel.logList.Count; i++)
            {
                string[] importLog = File.ReadAllLines($@"0:\System\Log\{DateTime.Now.ToShortDateString().Replace('/', '-')}.syslog");
                Array.Resize(ref importLog, importLog.Length + 1);
                if (Kernel.logList[i].warningLevel == LogWarningLevel.Information)
                {
                    importLog[importLog.Length - 1] = $@"{Kernel.logList[i].messageString} := Information";
                }
                else if (Kernel.logList[i].warningLevel == LogWarningLevel.Warning)
                {
                    importLog[importLog.Length - 1] = $@"{Kernel.logList[i].messageString} := Warning";
                }
                else if (Kernel.logList[i].warningLevel == LogWarningLevel.Error)
                {
                    importLog[importLog.Length - 1] = $@"{Kernel.logList[i].messageString} := Error";
                }

                File.WriteAllLines($@"0:\System\Log\{DateTime.Now.ToShortDateString().Replace('/', '-')}.syslog", importLog);
            }
        }
    }
}
