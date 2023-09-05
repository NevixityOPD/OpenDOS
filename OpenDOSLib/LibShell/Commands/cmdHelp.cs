using System;
using System.Collections.Generic;
using OpenDOSLib.LibSystem.User;

namespace OpenDOSLib.LibShell.Commands
{
    public class cmdHelp : Command
    {
        public string commandName => "help";
        public string commandDescription => "Shows helpful information for a certain command or more";
        public Elevation commandElevation => Elevation.User;
        public void executeCommand(List<string> args)
        {
            if(args.Count > 0)
            {
                int resultCounter = 0;
                for(int i = 0; i < OS.cmdMgr.registeredCommand.Length; i++)
                {
                    if(OS.cmdMgr.registeredCommand[i].commandName == args[0])
                    {
                        Console.WriteLine($"{OS.cmdMgr.registeredCommand[i].commandName}\t{OS.cmdMgr.registeredCommand[i].commandDescription}");
                        resultCounter++;
                    }
                }

                if(resultCounter == 0)
                {
                    Console.WriteLine($"Theres no such command as \"{args[0]}\" registered as internal command or external command");
                }
            }
            else if(args.Count == 0)
            {
                for(int i = 0; i < OS.cmdMgr.registeredCommand.Length; i++)
                {
                    Console.WriteLine($"{OS.cmdMgr.registeredCommand[i].commandName}\t{OS.cmdMgr.registeredCommand[i].commandDescription}");
                }
            }
        }
    }
}