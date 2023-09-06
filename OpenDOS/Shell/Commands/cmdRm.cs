﻿using System;
using System.Collections.Generic;
using System.IO;

namespace OpenDOS.Shell.Commands
{
    public class cmdRm : Command
    {
        public cmdRm() : base("rm", "Removes file or directory", User.UserElevation.Root) { }

        public override void cmdExecuteable(string[] args)
        {
            if (args.Length == 0)
            {
                Log.Log.ShowLog("rm: Input an argument!", Log.LogWarningLevel.Error);
            }
            else
            {
                if (args[0] == "-f" || args[0] == "--file")
                {
                    try
                    {
                        File.Delete(args[1]);
                    }
                    catch(Exception ex)
                    {
                        Log.Log.ShowLog($"rm: Error Occured {ex.Message}", Log.LogWarningLevel.Error);
                    }
                }
                else if (args[0] == "-d" || args[0] == "--dir")
                {
                    try
                    {
                        Directory.Delete(args[1], true);
                    }
                    catch (Exception ex)
                    {
                        Log.Log.ShowLog($"rm: Error Occured {ex.Message}", Log.LogWarningLevel.Error);
                    }
                }
            }
        }
    }
}
