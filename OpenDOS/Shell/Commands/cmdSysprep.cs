using System;
using System.Collections.Generic;

namespace OpenDOS.Shell.Commands
{
    public class cmdSysprep : Command
    {
        public cmdSysprep() : base("sysprep", "System preperation command", User.UserElevation.Guest) { }

        public override void cmdExecuteable(string[] args)
        {
            Setup.StartSetup sysprep = new Setup.StartSetup();
        }
    }
}
