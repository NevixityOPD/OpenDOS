using System.Collections.Generic;

namespace OpenDOSLib.LibShell
{
    public interface Command
    {
        string commandName { get; }
        string commandDescription { get; }
        LibSystem.User.Elevation commandElevation { get; }

        void executeCommand(List<string> args);
    }
}