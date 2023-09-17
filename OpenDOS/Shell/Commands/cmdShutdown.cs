using System;
using System.Collections.Generic;

namespace OpenDOS.Shell.Commands
{
    public class cmdShutdown : Command
    {
        public cmdShutdown() : base("shutdown", "Shutdowns.... No need explaination", User.UserElevation.Guest) { }

        public override void cmdExecuteable(string[] args)
        {
            Log.Log.SaveLog();

            Cosmos.System.Power.Shutdown();
        }
    }
}
