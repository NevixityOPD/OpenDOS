using System;
using System.Collections.Generic;
using System.IO;

namespace OpenDOS.Shell.Commands
{
    public class cmdUser : Command
    {
        public cmdUser() : base("user", "User command", User.UserElevation.User) { }

        public override void cmdExecuteable(string[] args)
        {
            if(args.Length == 0)
            {
                Log.Log.ShowLog("user: Input arguments!", Log.LogWarningLevel.Error);
            }
            else
            {
                if (args[0] == "list")
                {
                    for (int i = 0; i < Directory.GetFiles(@"0:\System\User\").Length; i++)
                    {
                        Console.WriteLine($@"[{i}]: {Path.GetFileName(Directory.GetFiles(@"0:\System\User\")[i])}");
                    }
                }
            }
        }
    }
}
