using System;
using System.IO;
using System.Collections.Generic;
using OpenDOSLib.LibSystem.User;

namespace OpenDOSLib.LibShell.Commands
{
    public class cmdMk : Command
    {
        public string commandName => "mk";
        public string commandDescription => "Command specifically created for making file(s) and directorie(s)";

        public Elevation commandElevation => Elevation.Root;

        public void executeCommand(List<string> args)
        {
            if(args[0] == "-f")
            {
                File.CreateText(args[1]);
            }
            else if(args[0] == "-d")
            {
                Directory.CreateDirectory(args[1]);
            }
        }
    }
}