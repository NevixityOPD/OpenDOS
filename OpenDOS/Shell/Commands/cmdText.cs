using System;
using System.Collections.Generic;

namespace OpenDOS.Shell.Commands
{
    public class cmdText : Command
    {
        public cmdText() : base("text", "Start text editor", User.UserElevation.User) { }

        public override void cmdExecuteable(string[] args)
        {
            IntegratedSoftware.TextEditor.TextEditor text = new();
            text.Start();
        }
    }
}
