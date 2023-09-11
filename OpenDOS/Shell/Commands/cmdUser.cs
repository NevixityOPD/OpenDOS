using OpenDOS.User;
using System;
using System.IO;

namespace OpenDOS.Shell.Commands
{
    public class cmdUser : Command
    {
        public cmdUser() : base("user", "User command", User.UserElevation.Root) { }

        public override void cmdExecuteable(string[] args)
        {
            if(args.Length == 0)
            {
                Log.Log.ShowLog("user: Input an arguments!", Log.LogWarningLevel.Error);
            }
            else
            {
                if (args[0] == "list")
                {
                    for (int i = 0; i < Directory.GetDirectories(@"0:\System\User\").Length; i++)
                    {
                        Console.WriteLine($@"[{i + 1}]: {Directory.GetDirectories(@"0:\System\User\")[i]}");
                    }
                }
                else if (args[0] == "add")
                {
                    Console.WriteLine("Create a new user\n");
                    ReInput:
                    Console.Write("Enter Username > ");
                    string usr = Console.ReadLine();
                    Console.Write("Enter Password > ");
                    string psw = Console.ReadLine();
                    if (usr == String.Empty || psw == String.Empty || usr == String.Empty && psw == String.Empty)
                    {
                        Console.WriteLine("Input cannot be empty!");
                        goto ReInput;
                    }
                    else
                    {
                        User.User newUser = new User.User()
                        {
                            userName = usr,
                            passWord = psw,
                            userElevation = UserElevation.User,
                        };
                        Kernel.usrMgr.AddUser(newUser);
                    }
                }
                else if (args[0] == "remove")
                {
                    for (int i = 0; i < Directory.GetDirectories($@"0:\System\User\").Length; i++)
                    {
                        if (Directory.GetDirectories($@"0:\System\User\")[i] == args[1])
                        {
                            Redo:
                            Console.Write("Do you want to proceed action?[y/n] > ");
                            ConsoleKeyInfo ck = Console.ReadKey();
                            Console.WriteLine();
                            if (ck.Key == ConsoleKey.Y)
                            {
                                File.Delete($@"0:\System\User\{args[1]}\{args[1]}.usr");
                                Directory.Delete($@"0:\System\User\{args[1]}\Data", true);
                                Directory.Delete($@"0:\System\User\{args[1]}\", true);
                                break;
                            }
                            else if (ck.Key == ConsoleKey.N)
                            {
                                Console.WriteLine("Root user will not be setted up\n");
                            }
                            else
                            {
                                Console.WriteLine("Please press y(es) or n(o)");
                                goto Redo;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"user: No user {args[1]}");
                        }
                    }
                }
            }
        }
    }
}
