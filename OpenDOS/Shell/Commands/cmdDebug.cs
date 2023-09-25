using System;
using System.Collections.Generic;

namespace OpenDOS.Shell.Commands
{
    public class cmdDebug : Command
    {
        public cmdDebug() : base("sysdebug", "System debug for developers", User.UserElevation.Guest) { }

        public override void cmdExecuteable(string[] args)
        {
            
        }
    }
}
