namespace OpenDOS.Shell
{
    public abstract class Command
    {
        //Commands name and description
        public string cmdName;
        public string cmdDesc;
        public User.UserElevation cmdElevation;
        //Commands implementable function
        public abstract void cmdExecuteable(string[] args);
        //Commands setter
        public Command(string n, string d, User.UserElevation e)
        {
            cmdName = n;
            cmdDesc = d;
            cmdElevation = e;
        }
    }
}
