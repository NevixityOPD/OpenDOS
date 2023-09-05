using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using OpenDOS.User;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
            PrintDebug("OpenDOS");
        }

        protected override void Run()
        {
            ConsoleGraphic.Write.WriteInColor("OpenDOS - ", ConsoleColor.Cyan);
            ConsoleGraphic.Write.WriteInColor($" {currentDir} - ", ConsoleColor.Green);
            ConsoleGraphic.Write.WriteInColor($" {currentUser.userName}", ConsoleColor.White);
            CodePage.Write("\n└> ");
            cmdMgr.commandFilter(Console.ReadLine());
        }
    }
}
