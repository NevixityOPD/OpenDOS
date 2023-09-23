using Cosmos.System.ExtendedASCII;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using OpenDOS.GUI;
using OpenDOS.Shell;
using OpenDOS.User;
using System;
using System.Collections.Generic;
using System.IO;
using Sys = Cosmos.System;

namespace OpenDOS
{
    public class Kernel : Sys.Kernel
    {
        public static ShellManager cmdMgr;
        public static CosmosVFS vFS;
        public static UserManager usrMgr;
        public static Config.ConfigManager cfgmgr;
        public static ConsoleGraphic.UI.UIManager uimgr;

        public static List<Log.LogMessage> logList;
        public static List<CommandLog> commandLogList;

        public static string currentDir = @"0:\";

        public static User.User currentUser = new User.User()
        {
            userName = "guest",
            passWord = "guest",
            userElevation = UserElevation.Guest,
        };

        protected override void BeforeRun()
        {
            Console.Clear();
            Console.OutputEncoding = CosmosEncodingProvider.Instance.GetEncoding(437);

            logList = new List<Log.LogMessage>();
            commandLogList = new List<CommandLog>();

            try
            {
                vFS = new CosmosVFS();
                VFSManager.RegisterVFS(vFS);
            }
            catch(Exception e)
            {
                Log.Log.ShowLog($"fs: Error occured {e.Message}", Log.LogWarningLevel.Error);
                Console.ReadKey();
            }
            cmdMgr = new ShellManager();
            usrMgr = new UserManager();
            cfgmgr = new Config.ConfigManager();
            uimgr = new ConsoleGraphic.UI.UIManager();

            Log.Log.ShowLog("Loading config, Please wait", Log.LogWarningLevel.Information);
            if (!File.Exists(@"0:\System\Config\SystemConfig.cfg"))
            {
                Log.Log.ShowLog("Config is missing. Please run sysprep", Log.LogWarningLevel.Warning);
            }
            else
            {
                for (int i = 0; i < File.ReadAllLines(@"0:\System\Config\SystemConfig.cfg").Length; i++)
                {
                    if (File.ReadAllLines(@"0:\System\Config\SystemConfig.cfg")[i].Split(':')[0] == "LoginAtStart" && File.ReadAllLines(@"0:\System\Config\SystemConfig.cfg")[i].Split(':')[1] == "true")
                    {
                        cmdMgr.commandFilter("login");
                    }
                }
                cmdMgr.commandFilter("clear");
            }

            Console.Clear();
            ConsoleGraphic.Write.WriteTopBar("Alpha 0.1(unstable)", ConsoleColor.Cyan);
        }

        protected override void Run()
        {
            if (Console.CursorTop == Console.WindowHeight - 1)
            {
                Console.Clear();
                ConsoleGraphic.Write.WriteTopBar("Alpha 0.1(unstable)", ConsoleColor.Cyan);
                Console.Write("┌─");
                ConsoleGraphic.Write.WriteInColor("OpenDOS", ConsoleColor.Cyan);
                ConsoleGraphic.Write.WriteInColor($" - ", ConsoleColor.White);
                ConsoleGraphic.Write.WriteInColor($"{currentDir}", ConsoleColor.Green);
                ConsoleGraphic.Write.WriteInColor($" - ", ConsoleColor.White);
                ConsoleGraphic.Write.WriteInColor($"{currentUser.userName}", ConsoleColor.White);
                Console.Write("\n└─> ");
                cmdMgr.commandFilter(Console.ReadLine());
            }
            else
            {
                Console.Write("┌─");
                ConsoleGraphic.Write.WriteInColor("OpenDOS", ConsoleColor.Cyan);
                ConsoleGraphic.Write.WriteInColor($" - ", ConsoleColor.White);
                ConsoleGraphic.Write.WriteInColor($"{currentDir}", ConsoleColor.Green);
                ConsoleGraphic.Write.WriteInColor($" - ", ConsoleColor.White);
                ConsoleGraphic.Write.WriteInColor($"{currentUser.userName}", ConsoleColor.White);
                Console.Write("\n└─> ");
                cmdMgr.commandFilter(Console.ReadLine());
            }
        }
    }
}
