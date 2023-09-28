using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OpenDOS.Shell.Commands
{
    public class cmdConfig : Command
    {
        public cmdConfig() : base("conf", "Configuration command used to manage system or global config", User.UserElevation.User) { }

        private Config.ConfigType? selectedConfigType;
        public override void cmdExecuteable(string[] args)
        {
            if (args.Length == 0)
            {
                Kernel.expmgr.ThrowBasicException("conf", "Input an argument!");
            }
            else
            {
                if (args[0].ToLower() == "sel")
                {
                    if (args[1] != string.Empty)
                    {
                        if (args[1].ToLower() == "sys")
                        {
                            selectedConfigType = Config.ConfigType.SystemConfig;
                            Console.WriteLine("System config is selected");
                        }
                        else if (args[1].ToLower() == "global")
                        {
                            selectedConfigType = Config.ConfigType.GlobalConfig;
                            Console.WriteLine("Global config is selected");
                        }
                        else
                        {
                            Kernel.expmgr.ThrowBasicException("conf", "No config type was selected");
                        }
                    }
                }
                else if (args[0].ToLower() == "list")
                {
                    if (selectedConfigType == null)
                    {
                        Kernel.expmgr.ThrowBasicException("conf", "Config type is not selected yet");
                    }
                    else if (selectedConfigType == Config.ConfigType.SystemConfig)
                    {
                        if (Kernel.currentUser.userElevation != User.UserElevation.Root)
                        {
                            Kernel.expmgr.ThrowBasicException("conf", "User must be a root to change any system config");
                        }
                        else
                        {
                            for (int i = 0; i < File.ReadAllLines(@"0:\System\Config\SystemConfig.cfg").Length; i++)
                            {
                                Console.WriteLine($"[{i}] - conf:{File.ReadAllLines(@"0:\System\Config\SystemConfig.cfg")[i].Split(':')[0]} val:{File.ReadAllLines(@"0:\System\Config\SystemConfig.cfg")[i].Split(':')[1]}");
                            }
                        }
                    }
                    else if (selectedConfigType == Config.ConfigType.GlobalConfig)
                    {
                        for (int i = 0; i < File.ReadAllLines(@"0:\System\Config\GlobalConfig.cfg").Length; i++)
                        {
                            Console.WriteLine($"[{i}] - conf:{File.ReadAllLines(@"0:\System\Config\GlobalConfig.cfg")[i].Split(':')[0]} val:{File.ReadAllLines(@"0:\System\Config\GlobalConfig.cfg")[i].Split(':')[1]}");
                        }
                    }
                }
                else if (args[0].ToLower() == "add")
                {
                    if (selectedConfigType == null)
                    {
                        Console.WriteLine("Please select config type");
                    }
                    else if (selectedConfigType == Config.ConfigType.SystemConfig)
                    {
                        if (Kernel.currentUser.userElevation != User.UserElevation.Root)
                        {
                            Console.WriteLine("User must be a root to do any change to system config");
                        }
                        else
                        {
                            if (args[2] != string.Empty && args[1] != string.Empty || args[1] != string.Empty)

                            Kernel.cfgmgr.AddConfig(new Config.Config(args[2], args[1]), Config.ConfigType.SystemConfig);
                        }
                    }
                    else if (selectedConfigType == Config.ConfigType.GlobalConfig)
                    {
                        Kernel.cfgmgr.AddConfig(new Config.Config(args[2], args[1]), Config.ConfigType.GlobalConfig);
                    }
                    else
                    {
                        Kernel.expmgr.ThrowBasicException("conf", "Input an argument!");
                    }
                }
                else if (args[0].ToLower() == "remove")
                {
                    if (selectedConfigType == null)
                    {
                        Console.WriteLine("Please select config type");
                    }
                    else if (selectedConfigType == Config.ConfigType.SystemConfig)
                    {
                        if (Kernel.currentUser.userElevation != User.UserElevation.Root)
                        {
                            Console.WriteLine("User must be a root to do any change to system config");
                        }
                        else
                        {
                            string[] strcp = File.ReadAllLines(@"0:\System\Config\SystemConfig.cfg");

                            for (int i = 0; i < strcp.Length; i++)
                            {
                                if (strcp[i].Split(':')[0] == args[1])
                                {
                                    strcp[i] = string.Empty;
                                }
                            }

                            Array.Resize(ref strcp, strcp.Length - 1);
                            File.CreateText(@"0:\System\Config\SystemConfig.cfg");
                            File.WriteAllLines(@"0:\System\Config\SystemConfig.cfg", strcp);
                        }
                    }
                    else if (selectedConfigType == Config.ConfigType.GlobalConfig)
                    {
                        List<string> globalConf = File.ReadAllLines(@"0:\System\Config\GlobalConfig.cfg").ToList();
                        for (int i = 0; i < globalConf.Count; i++)
                        {
                            if (globalConf[i].Split(':')[0] == args[1])
                            {
                                globalConf[i] = string.Empty;
                            }
                        }
                        File.Delete(@"0:\System\Config\GlobalConfig.cfg");
                        File.CreateText(@"0:\System\Config\GlobalConfig.cfg");
                        File.WriteAllLines(@"0:\System\Config\GlobalConfig.cfg", globalConf);
                    }
                    else
                    {
                        Kernel.expmgr.ThrowBasicException("conf", "Input an argument!");
                    }
                }
            }
        }
    }
}
