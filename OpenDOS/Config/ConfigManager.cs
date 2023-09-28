using System;
using System.Collections.Generic;
using System.IO;

namespace OpenDOS.Config
{
    public class ConfigManager
    {
        public void AddConfig(Config newConfig, ConfigType configType)
        {
            switch (configType)
            {
                case ConfigType.SystemConfig:
                    if (Kernel.currentUser.userElevation != User.UserElevation.Root)
                    {
                        Log.Log.ShowLog("User must be a root to write config into System configuration", Log.LogWarningLevel.Error, Log.LogWritter.System);
                    }
                    else
                    {
                        if (!File.Exists(@"0:\System\Config\SystemConfig.cfg"))
                        {
                            Log.Log.ShowLog("System configuration is missing. Please run sysprep", Log.LogWarningLevel.Error, Log.LogWritter.System);
                        }
                        else
                        {
                            try
                            {
                                string[] strcp = File.ReadAllLines(@"0:\System\Config\SystemConfig.cfg");
                                if (strcp.Length == 0)
                                {
                                    File.WriteAllText(@"0:\System\Config\SystemConfig.cfg", $@"{newConfig.configName}:{newConfig.configValue}");
                                }
                                else
                                {
                                    Array.Resize(ref strcp, strcp.Length + 1);
                                    strcp[strcp.Length - 1] = $"{newConfig.configName}:{newConfig.configValue}";
                                    File.WriteAllLines(@"0:\System\Config\SystemConfig.cfg", strcp);
                                }
                            }
                            catch (System.Exception ex)
                            {
                                Log.Log.ShowLog($"cfgmgr: Error occured {ex.Message}", Log.LogWarningLevel.Error, Log.LogWritter.System);
                            }
                        }
                    }
                    break;
                case ConfigType.GlobalConfig:
                    if (!File.Exists(@"0:\System\Config\GlobalConfig.cfg"))
                    {
                        Log.Log.ShowLog("Global configuration is missing. Please run sysprep", Log.LogWarningLevel.Error, Log.LogWritter.System);
                    }
                    else
                    {
                        try
                        {
                            File.WriteAllText(@"0:\System\Config\GlobalConfig.cfg", $@"{newConfig.configName}:{newConfig.configValue}");
                        }
                        catch (System.Exception ex)
                        {
                            Log.Log.ShowLog($"cfgmgr: Error occured {ex.Message}", Log.LogWarningLevel.Error, Log.LogWritter.System);
                        }
                    }
                    break;
            }
        }
    }
}
