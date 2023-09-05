using System;
using System.Collections.Generic;

namespace OpenDOS.Shell.Commands
{
    public class cmdRm : Command
    {
        public cmdRm() : base("", "", User.UserElevation.User) { }
    }
}
