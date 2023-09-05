using System;
using System.Collections.Generic;

namespace OpenDOS.Shell.Commands
{
    public class cmdCd : Command
    {
        public cmdCd() : base("cd", "Changes directory", User.UserElevation.User) { }

        public override void cmdExecuteable(string[] args)
        {
            if (args.Length == 0)
            {
                Kernel.currentDir = @"0:\";
            }
            else
            {
                Kernel.currentDir = args[0];
            }
        }
    }
}
