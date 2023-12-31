﻿using System;
using System.Collections.Generic;
using System.IO;

namespace OpenDOS.Shell
{
    public class ShellManager
    {
        //List of registered commands
        public List<Command> shellCommand;
        
        public ShellManager()
        {
            shellCommand = new List<Command>()
            {
                new Commands.cmdEcho(),
                new Commands.cmdClear(),
                new Commands.cmdSysprep(),
                new Commands.cmdHelp(),
                new Commands.cmdList(),
                new Commands.cmdCd(),
                new Commands.cmdLogin(),
                new Commands.cmdWhoami(),
                new Commands.cmdUser(),
                new Commands.cmdMk(),
                new Commands.cmdRm(),
                new Commands.cmdRead(),
                new Commands.cmdConfig(),
                new Commands.cmdShutdown(),
                new Commands.cmdText(),
                new Commands.cmdDebug(),
                new Commands.cmdLog(),
            };
        }
        //Filter command and execute command with a certain name
        public void commandFilter(string s)
        {
            string[] unfilteredArgs = s.Split(' '); //Splits up command after every space or blackspace into and args
            string command = unfilteredArgs[0]; //Specify command
            int searchResult = 0; //Checks if command exist as a int
            
            List<string> args = new List<string>(); //Important list as an argument for every command

            for (int i = 0; i < unfilteredArgs.Length; i++) //Filter args
            {
                if (unfilteredArgs[i] != command)
                {
                    args.Add(unfilteredArgs[i]);
                }
            }

            for (int i = 0; i < shellCommand.Count; i++) //Checks if command exist
            {
                if (shellCommand[i].cmdName == command)
                {
                    if (shellCommand[i].cmdElevation == User.UserElevation.Guest)
                    {
                        if (Kernel.currentUser.userElevation == User.UserElevation.Guest)
                        {
                            try
                            {
                                shellCommand[i].cmdExecuteable(args.ToArray());
                            }
                            catch(System.Exception e)
                            {
                                Kernel.expmgr.ThrowBasicException(shellCommand[i].cmdName, e.Message);
                            }
                            searchResult++;
                        }
                        else if (Kernel.currentUser.userElevation == User.UserElevation.User)
                        {
                            try
                            {
                                shellCommand[i].cmdExecuteable(args.ToArray());
                            }
                            catch (System.Exception e)
                            {
                                Kernel.expmgr.ThrowBasicException(shellCommand[i].cmdName, e.Message);
                            }
                            searchResult++;
                        }
                        else if (Kernel.currentUser.userElevation == User.UserElevation.Root)
                        {
                            try
                            {
                                shellCommand[i].cmdExecuteable(args.ToArray());
                            }
                            catch (System.Exception e)
                            {
                                Kernel.expmgr.ThrowBasicException(shellCommand[i].cmdName, e.Message);
                            }
                            searchResult++;
                        }
                    }
                    else if (shellCommand[i].cmdElevation == User.UserElevation.User)
                    {
                        if (Kernel.currentUser.userElevation == User.UserElevation.Guest)
                        {
                            if (Kernel.usrMgr.VerifyUser())
                            {
                                try
                                {
                                    shellCommand[i].cmdExecuteable(args.ToArray());
                                }
                                catch (System.Exception e)
                                {
                                    Kernel.expmgr.ThrowBasicException(shellCommand[i].cmdName, e.Message);
                                }
                                searchResult++;
                            }
                            searchResult++;
                        }
                        else if (Kernel.currentUser.userElevation == User.UserElevation.User)
                        {
                            try
                            {
                                shellCommand[i].cmdExecuteable(args.ToArray());
                            }
                            catch (System.Exception e)
                            {
                                Kernel.expmgr.ThrowBasicException(shellCommand[i].cmdName, e.Message);
                            }
                            searchResult++;
                        }
                        else if (Kernel.currentUser.userElevation == User.UserElevation.Root)
                        {
                            try
                            {
                                shellCommand[i].cmdExecuteable(args.ToArray());
                            }
                            catch (System.Exception e)
                            {
                                Kernel.expmgr.ThrowBasicException(shellCommand[i].cmdName, e.Message);
                            }
                            searchResult++;
                        }
                    }
                    else if (shellCommand[i].cmdElevation == User.UserElevation.Root)
                    {
                        if (Kernel.currentUser.userElevation == User.UserElevation.Guest)
                        {
                            if (Kernel.usrMgr.VerifyUser())
                            {
                                try
                                {
                                    shellCommand[i].cmdExecuteable(args.ToArray());
                                }
                                catch (System.Exception e)
                                {
                                    Kernel.expmgr.ThrowBasicException(shellCommand[i].cmdName, e.Message);
                                }
                                searchResult++;
                            }
                            searchResult++;
                        }
                        else if (Kernel.currentUser.userElevation == User.UserElevation.User)
                        {
                            if (Kernel.usrMgr.VerifyUser())
                            {
                                try
                                {
                                    shellCommand[i].cmdExecuteable(args.ToArray());
                                }
                                catch (System.Exception e)
                                {
                                    Kernel.expmgr.ThrowBasicException(shellCommand[i].cmdName, e.Message);
                                }
                                searchResult++;
                            }
                            searchResult++;
                        }
                        else if (Kernel.currentUser.userElevation == User.UserElevation.Root)
                        {
                            try
                            {
                                shellCommand[i].cmdExecuteable(args.ToArray());
                            }
                            catch (System.Exception e)
                            {
                                Kernel.expmgr.ThrowBasicException(shellCommand[i].cmdName, e.Message);
                            }
                            searchResult++;
                        }
                    }
                }
            }

            if(searchResult == 0)
            {
                Log.Log.ShowLog($"shell: \"{command}\" does not exist", Log.LogWarningLevel.Error, Log.LogWritter.System);
            }
        }


        public int commandCount()
        {
            return shellCommand.Count;
        }
    }
}
