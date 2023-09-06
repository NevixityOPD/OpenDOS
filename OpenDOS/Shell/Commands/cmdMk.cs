using System;
using System.IO;

namespace OpenDOS.Shell.Commands
{
    public class cmdMk : Command
    {
        public cmdMk() : base("mk", "Creates file or directory", User.UserElevation.Root) { }

        public override void cmdExecuteable(string[] args)
        {
            if (args.Length == 0)
            {
                Log.Log.ShowLog("mk: Input an argument!", Log.LogWarningLevel.Error);
            }
            else
            {
                if (args[0] == "-f" || args[0] == "--file")
                {
                    try
                    {
                        File.CreateText(args[1]);
                    }
                    catch (Exception ex)
                    {
                        Log.Log.ShowLog($"mk: Error Occured {ex.Message}", Log.LogWarningLevel.Error);
                    }
                }
                else if (args[0] == "-d" || args[0] == "--dir")
                {
                    try
                    {
                        Directory.CreateDirectory(args[1]);
                    }
                    catch (Exception ex)
                    {
                        Log.Log.ShowLog($"mk: Error Occured {ex.Message}", Log.LogWarningLevel.Error);
                    }
                }
            }
        }
    }
}
