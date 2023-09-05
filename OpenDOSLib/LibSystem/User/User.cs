using System;

namespace OpenDOSLib.LibSystem.User
{
    public class User
    {
        public string userName;
        public string passWord;
        public Elevation userElevation;
        public bool IsLogin = false;

        public void changeUsername()
        {
            if(grantPermission())
            {
                OS.Log("Enter new username : ", "user", false);
                string inp = Console.ReadLine();
                if(inp == null || inp == String.Empty)
                {
                    Console.WriteLine("Input is null");
                }
                else
                {
                    userName = inp;
                }
            }
            else
            {
                Console.WriteLine("Wrong Password");
            }
        }

        public void changePassword()
        {
            if(grantPermission())
            {
                OS.Log("Enter new password : ", "user", false);
                string inp = Console.ReadLine();
                if(inp == null || inp == String.Empty)
                {
                    Console.WriteLine("Input is null");
                }
                else
                {
                    passWord = inp;
                }
            }
            else
            {
                Console.WriteLine("Wrong Password");
            }
        }

        public bool grantPermission()
        {
            OS.Log("Enter User Password : ", "access", false);
            string inputPassword = Console.ReadLine();
            if(inputPassword == passWord)
            {
                return true;
            }
            return false;
        }

        public void userLogin()
        {
            if(IsLogin)
            {
                Console.WriteLine("User is already logged in");
            }
            else
            {
                bool continueRun = true;
                Console.WriteLine("User Login");
                while(continueRun)
                {
                    Console.Write($"Enter {userName} Password : ");
                    string usrn = Console.ReadLine();
                    for(int i = 0; i < OS.systemUser.Length; i++)
                    {
                        if(OS.systemUser[i].passWord == usrn)
                        {
                            Console.WriteLine("User logged in");
                            IsLogin = true;
                            OS.loggedUser = OS.systemUser[i];
                            continueRun = false;
                        }
                    }
                }
            }
        }
    }
}