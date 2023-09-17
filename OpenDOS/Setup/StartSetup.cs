﻿using OpenDOS.User;
using System;
using System.IO;

namespace OpenDOS.Setup
{
    public class StartSetup
    {
        public StartSetup()
        {
            Console.Clear();
            Kernel.currentUser = new User.User()
            {
                userName = "installer",
                passWord = "temp",
                userElevation = UserElevation.Root,
            };
            Console.WriteLine("**********************************************");
            Console.WriteLine("*                                            *");
               CodePage.Write("*        █▀█ █▀█ █▀▀ █▄░█ █▀▄ █▀█ █▀         *\n");
               CodePage.Write("*        █▄█ █▀▀ ██▄ █░▀█ █▄▀ █▄█ ▄█ v1.0    *\n");
            Console.WriteLine("*                                            *");
            Console.WriteLine("**********************************************");
            Console.WriteLine("Created by Nevixity");
            Console.WriteLine("This is early build, things meant to change\n");
            CreateSystemDirectory();
            CreateConfig();
            Kernel.cfgmgr.AddConfig(new Config.Config("true", "LoginAtStart"), Config.ConfigType.SystemConfig);
            Log.Log.ShowLog("System directories and system config has been created", Log.LogWarningLevel.Information);
            Console.WriteLine("Create a new user\n");
            ReInput:
            Console.Write("Enter Username > ");
            string usr = Console.ReadLine();
            Console.Write("Enter Password > ");
            string psw = Console.ReadLine();
            if (usr == String.Empty || psw == String.Empty || usr == String.Empty && psw == String.Empty)
            {
                Console.WriteLine("Input cannot be empty!");
                goto ReInput;
            }
            else
            {
                User.User newUser = new User.User()
                {
                    userName = usr,
                    passWord = psw,
                    userElevation = UserElevation.User,
                };
                Kernel.usrMgr.AddUser(newUser);
            }

            Redo:
            Console.Write("Do you want to set up root user?[y/n] > ");
            ConsoleKeyInfo ck = Console.ReadKey();
            Console.WriteLine();
            if (ck.Key == ConsoleKey.Y)
            {
                User.User rootUser = new User.User()
                {
                    userName = "root",
                    passWord = "root",
                    userElevation = UserElevation.Root,
                };
                Kernel.usrMgr.AddUser(rootUser);
            }
            else if (ck.Key == ConsoleKey.N)
            {
                Console.WriteLine("Root user will not be setted up\n");
            }
            else
            {
                Console.WriteLine("Please press y(es) or n(o)");
                goto Redo;
            }

            Console.WriteLine("Setup has been completed, Press any key to reboot...");
            Cosmos.System.Power.Reboot();
        }

        private void CreateSystemDirectory()
        {
            Log.Log.ShowLog("Creating system directory", Log.LogWarningLevel.Information);
            Directory.CreateDirectory(@"0:\System");
            Directory.CreateDirectory(@"0:\System\User");
            Directory.CreateDirectory(@"0:\System\Config");
            Directory.CreateDirectory(@"0:\System\Log");
            Directory.CreateDirectory(@"0:\System\Temp");
            Directory.CreateDirectory(@"0:\System\Log\CommandLog");

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
            if (!Directory.Exists(@"0:\System\Log"))
            {
                Log.Log.ShowLog("Failed to create Log directory. Re-creating directory", Log.LogWarningLevel.Error);
                Directory.CreateDirectory(@"0:\System\Log");
            }
            if (!Directory.Exists(@"0:\System\Temp"))
            {
                Log.Log.ShowLog("Failed to create Temp directory. Re-creating directory", Log.LogWarningLevel.Error);
                Directory.CreateDirectory(@"0:\System\Temp");
            }
        }

        private void CreateConfig()
        {
            try
            {
                Log.Log.ShowLog("Creating System Config", Log.LogWarningLevel.Information);
                File.CreateText(@"0:\System\Config\SystemConfig.cfg");
                Log.Log.ShowLog("Creating Global Config", Log.LogWarningLevel.Information);
                File.CreateText(@"0:\System\Config\GlobalConfig.cfg");
            }
            catch
            {
                Log.Log.ShowLog("Failed to create config", Log.LogWarningLevel.Error);
            }
        }
    }
}
