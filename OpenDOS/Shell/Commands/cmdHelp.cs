using System;
using System.Collections.Generic;

namespace OpenDOS.Shell.Commands
{
    public class cmdHelp : Command
    {
        public cmdHelp() : base("help", "Shows this text", User.UserElevation.Guest) { }

        public override void cmdExecuteable(string[] args)
        {
            if (args.Length == 0)
            {
                for (int i = 0; i < Kernel.cmdMgr.shellCommand.Count; i++)
                {
                    Console.WriteLine($"{Kernel.cmdMgr.shellCommand[i].cmdName}\t{Kernel.cmdMgr.shellCommand[i].cmdDesc}");
                }
            }
            else if (args.Length > 0)
            {
                for (int i = 0; i < Kernel.cmdMgr.shellCommand.Count; i++)
                {
                    if (Kernel.cmdMgr.shellCommand[i].cmdName == args[0])
                    {
                        Console.WriteLine($"{Kernel.cmdMgr.shellCommand[i].cmdName}\t{Kernel.cmdMgr.shellCommand[i].cmdDesc}");
                    }
                }
            }
            Console.WriteLine($"\n{Kernel.cmdMgr.commandCount()}");
        }
    }
}
