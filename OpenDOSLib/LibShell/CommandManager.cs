using System;
using System.Collections.Generic;

namespace OpenDOSLib.LibShell
{
    public class CommandManager
    {
        public readonly Command[] registeredCommand = new Command[]
        {
            new Commands.cmdSysinfo(),
            new Commands.cmdSystemCommand(),
            new Commands.cmdLogin(),
            new Commands.cmdHelp(),
            new Commands.cmdMk(),
        };

        public void checkCommand(string input)
        {
            string[] tempArray = input.Split(' ');
            List<string> args = new List<string>();
            for(int i = 0; i < tempArray.Length; i++)
            {
                if(tempArray[i] != tempArray[0])
                {
                    args.Add(tempArray[i]);
                }
            }

            for(int i = 0; i < registeredCommand.Length; i++)
            {
                if(registeredCommand[i].commandName == tempArray[0])
                {
                    if(registeredCommand[i].commandElevation == LibSystem.User.Elevation.User)
                    {
                        if(OS.loggedUser.userElevation == LibSystem.User.Elevation.User)
                        {
                            registeredCommand[i].executeCommand(args);
                        }
                        else if(OS.loggedUser.userElevation == LibSystem.User.Elevation.Root)
                        {
                            registeredCommand[i].executeCommand(args);
                        }
                        else if(OS.loggedUser.userElevation == LibSystem.User.Elevation.Guest)
                        {
                            Console.WriteLine("Please log into a user account");
                        }
                    }
                    else if(registeredCommand[i].commandElevation == LibSystem.User.Elevation.Root)
                    {
                        if(OS.loggedUser.userElevation == LibSystem.User.Elevation.User)
                        {
                            Console.WriteLine("Please log into a user account");
                        }
                        else if(OS.loggedUser.userElevation == LibSystem.User.Elevation.Root)
                        {
                            registeredCommand[i].executeCommand(args);
                        }
                        else if(OS.loggedUser.userElevation == LibSystem.User.Elevation.Guest)
                        {
                            Console.WriteLine("Please log into a user account");
                        }
                    }
                    else if(registeredCommand[i].commandElevation == LibSystem.User.Elevation.Guest)
                    {
                        if(OS.loggedUser.userElevation == LibSystem.User.Elevation.User)
                        {
                            registeredCommand[i].executeCommand(args);
                        }
                        else if(OS.loggedUser.userElevation == LibSystem.User.Elevation.Root)
                        {
                            registeredCommand[i].executeCommand(args);
                        }
                        else if(OS.loggedUser.userElevation == LibSystem.User.Elevation.Guest)
                        {
                            registeredCommand[i].executeCommand(args);
                        }
                    }
                }
            }
        }
    }
}