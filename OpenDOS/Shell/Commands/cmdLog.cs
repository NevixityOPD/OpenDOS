using System;
using System.Text;

namespace OpenDOS.Shell.Commands
{
    public class cmdLog : Command
    {
        public cmdLog() : base("log", "Logging for user", User.UserElevation.User) { }

        public override void cmdExecuteable(string[] args)
        {
            string title = string.Empty;

            for(int i = 0; i < args.Length; i++)
            {
                if (i != 0)
                {
                    title += $"{args[i]} ";
                }
            }

            switch (args[0])
            {
                case "warn":
                    Log.Log.ShowLog(title, Log.LogWarningLevel.Warning, Log.LogWritter.User);
                    break;
                case "info":
                    Log.Log.ShowLog(title, Log.LogWarningLevel.Information, Log.LogWritter.User);
                    break;
                case "error":
                    Log.Log.ShowLog(title, Log.LogWarningLevel.Error, Log.LogWritter.User);
                    break;
                default:
                    Log.Log.ShowLog("Enter a correct logging format!", Log.LogWarningLevel.Error, Log.LogWritter.System);
                    break;
            }
        }
    }
}
