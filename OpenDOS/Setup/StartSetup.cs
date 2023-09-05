using OpenDOS.User;
using System;
using System.IO;

namespace OpenDOS.Setup
{
    public class StartSetup
    {
        public StartSetup()
        {
            Console.Clear();
            Console.WriteLine("**********************************************");
            Console.WriteLine("*                                            *");
               CodePage.Write("*        █▀█ █▀█ █▀▀ █▄░█ █▀▄ █▀█ █▀         *\n");
               CodePage.Write("*        █▄█ █▀▀ ██▄ █░▀█ █▄▀ █▄█ ▄█ v1.0    *\n");
            Console.WriteLine("*                                            *");
            Console.WriteLine("**********************************************");
            Console.WriteLine("Created by Nevixity");
            Console.WriteLine("This is early build, things meant to change\n");

            CreateSystemDirectory();
            Log.Log.ShowLog("System directories has been created", Log.LogWarningLevel.Information);
            Console.WriteLine("Create a new user\n");
            Console.Write("Enter Username > ");
            string usr = Console.ReadLine();
            Console.Write("Enter Password > ");
            string psw = Console.ReadLine();
            User.User newUser = new User.User()
            {
                userName = usr,
                passWord = psw,
                userElevation = UserElevation.User,
            };
            Kernel.usrMgr.AddUser(newUser);
            Console.WriteLine("Setup has been completed, Press any key to reboot...");
            Cosmos.System.Power.Reboot();
        }

        private void CreateSystemDirectory()
        {
            Log.Log.ShowLog("Creating system directory", Log.LogWarningLevel.Information);
            Directory.CreateDirectory(@"0:\System");
            Directory.CreateDirectory(@"0:\System\User");
            Directory.CreateDirectory(@"0:\System\Config");
            
            if (!Directory.Exists(@"0:\System"))
            {
                Log.Log.ShowLog("Failed to create System directory. Re-creating directory", Log.LogWarningLevel.Error);
                Directory.CreateDirectory(@"0:\System");
            }
            if (!Directory.Exists(@"0:\System\User"))
            {
                Log.Log.ShowLog("Failed to create User directory. Re-creating directory", Log.LogWarningLevel.Error);
                Directory.CreateDirectory(@"0:\System\User");
            }
            if (!Directory.Exists(@"0:\System\Config"))
            {
                Log.Log.ShowLog("Failed to create Config directory. Re-creating directory", Log.LogWarningLevel.Error);
                Directory.CreateDirectory(@"0:\System\Config");
            }
        }
    }
}
