using System;
using System.Collections.Generic;

namespace OpenDOS.Shell.Commands
{
    public class cmdLogin : Command
    {
        public cmdLogin() : base("login", "Logged into a user", User.UserElevation.Guest) { }

        public override void cmdExecuteable(string[] args)
        {
            Kernel.usrMgr.Login();
        }
    }
}
