using System;
using System.Collections.Generic;

namespace OpenDOS.Shell.Commands
{
    public class cmdWhoami : Command
    {
        public cmdWhoami() : base("whoami", "Print current logged in user", User.UserElevation.Guest) { }

        public override void cmdExecuteable(string[] args)
        {
            Console.WriteLine($"{Kernel.currentUser.userName}\\{Kernel.usrMgr.ConvertEnum(Kernel.currentUser)}");
        }
    }
}
