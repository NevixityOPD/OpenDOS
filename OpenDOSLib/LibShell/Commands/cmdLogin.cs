using System;
using System.Collections.Generic;
using OpenDOSLib.LibSystem.User;

namespace OpenDOSLib.LibShell.Commands
{
    public class cmdLogin : Command
    {
        public string commandName => "login";
        public string commandDescription => "Logged into any included account";
        public Elevation commandElevation => Elevation.Guest;
        public void executeCommand(List<string> args)
        {
            if(args.Count > 0)
            {
                if(args[0] == "-l")
                {
                    for(int i = 0; i < OS.systemUser.Length; i++)
                    {
                        if(OS.systemUser[i].userElevation == Elevation.User)
                        {
                            Console.WriteLine($"Username : {OS.systemUser[i].userName} / Elevation : User / Is Logged In : {OS.systemUser[i].IsLogin.ToString()}");
                        }
                    }
                }
                else
                {
                    for(int i = 0; i < OS.systemUser.Length; i++)
                    {
                        if(args[0] == OS.systemUser[i].userName)
                        {
                            OS.systemUser[i].userLogin();
                        }
                    }
                }
            }
        }
    }
}