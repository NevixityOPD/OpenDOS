using System;
using System.Collections.Generic;

namespace OpenDOS.Shell.Commands
{
    public class cmdConsoleUI : Command
    {
        public cmdConsoleUI() : base("ui", "Console User Interface", User.UserElevation.User) { }

        public override void cmdExecuteable(string[] args)
        {
            Console.Clear();
            ConsoleGraphic.UI.UIManager ui = new ConsoleGraphic.UI.UIManager();
            ui.Render("Test Window");
        }
    }
}
