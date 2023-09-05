using System;
using System.Collections.Generic;

namespace OpenDOS.Shell.Commands
{
    public class cmdClear : Command
    {
        public cmdClear() : base("clear", "Clears the screen", User.UserElevation.Guest) { }

        public override void cmdExecuteable(string[] args)
        {
            Console.Clear();
        }
    }
}
