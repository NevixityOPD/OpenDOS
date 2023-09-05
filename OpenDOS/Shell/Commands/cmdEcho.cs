using System;
using System.Collections.Generic;

namespace OpenDOS.Shell.Commands
{
    public class cmdEcho : Command
    {
        public cmdEcho() : base("echo", "Echoes text", User.UserElevation.Guest) { }

        public override void cmdExecuteable(string[] args)
        {
            for(int i = 0; i < args.Length; i++)
            {
                Console.Write($"{args[i]} ");
            }
            Console.WriteLine();
        }
    }
}
