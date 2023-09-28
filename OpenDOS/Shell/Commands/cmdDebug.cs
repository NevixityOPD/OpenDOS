using System;
using System.Collections.Generic;

namespace OpenDOS.Shell.Commands
{
    public class cmdDebug : Command
    {
        public cmdDebug() : base("sysdebug", "System debug for developers", User.UserElevation.Guest) { }

        public override void cmdExecuteable(string[] args)
        {
            Kernel.uimgr.AutoReturn = true;

            Kernel.uimgr.Render("UI Debug Test");
            Kernel.uimgr.WriteLine("Test Debug WriteLine");
            Console.ReadKey();

            string[] option = new string[] { "Option Test #1", "Option Test #2" };
            int sel = 0;

            while (true)
            {
                Kernel.uimgr.Clear();
                for (int i = 0; i < option.Length; i++)
                {
                    if (sel == i)
                    {
                        Kernel.uimgr.WriteLine($"- {option[i]} -");
                    }
                    else
                    {
                        Kernel.uimgr.WriteLine($"{option[i]}");
                    }
                }

                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (sel != 0)
                    {
                        sel--;
                    }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (sel != option.Length - 1)
                    {
                        sel++;
                    }
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }

            Kernel.cmdMgr.commandFilter("clear");
        }
    }
}
