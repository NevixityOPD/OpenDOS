using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using OpenDOS.User;
using System;
using Sys = Cosmos.System;

namespace OpenDOS
{
    public class Kernel : Sys.Kernel
    {
        public static Shell.ShellManager cmdMgr;
        public static CosmosVFS vFS;
        public static UserManager usrMgr;

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
            vFS = new CosmosVFS();
            VFSManager.RegisterVFS(vFS);
            cmdMgr = new Shell.ShellManager();
            usrMgr = new UserManager();
            ConsoleGraphic.Write.WriteTopBar("", ConsoleColor.Cyan);
        }

        protected override void Run()
        {
            if (Console.CursorTop == Console.WindowHeight - 1)
            {
                Console.Clear();
                ConsoleGraphic.Write.WriteTopBar("", ConsoleColor.Cyan);
                ConsoleGraphic.Write.WriteInColor("OpenDOS", ConsoleColor.Cyan);
                ConsoleGraphic.Write.WriteInColor($" - ", ConsoleColor.White);
                ConsoleGraphic.Write.WriteInColor($"{currentDir}", ConsoleColor.Green);
                ConsoleGraphic.Write.WriteInColor($" - ", ConsoleColor.White);
                ConsoleGraphic.Write.WriteInColor($"{currentUser.userName}", ConsoleColor.White);
                CodePage.Write("\n└─> ");
                cmdMgr.commandFilter(Console.ReadLine());
            }
            else
            {
                ConsoleGraphic.Write.WriteInColor("OpenDOS", ConsoleColor.Cyan);
                ConsoleGraphic.Write.WriteInColor($" - ", ConsoleColor.White);
                ConsoleGraphic.Write.WriteInColor($"{currentDir}", ConsoleColor.Green);
                ConsoleGraphic.Write.WriteInColor($" - ", ConsoleColor.White);
                ConsoleGraphic.Write.WriteInColor($"{currentUser.userName}", ConsoleColor.White);
                CodePage.Write("\n└─> ");
                cmdMgr.commandFilter(Console.ReadLine());
            }
        }
    }
}
