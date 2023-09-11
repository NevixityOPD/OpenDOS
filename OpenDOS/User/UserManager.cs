using System;
using System.IO;

namespace OpenDOS.User
{
    public class UserManager
    {
        public void AddUser(User newUser)
        {
            Directory.CreateDirectory($@"0:\System\User\{newUser.userName}\");
            Directory.CreateDirectory($@"0:\System\User\{newUser.userName}\Data");
            File.Create($@"0:\System\User\{newUser.userName}\{newUser.userName}.usr");
            File.WriteAllLines($@"0:\System\User\{newUser.userName}\{newUser.userName}.usr", new string[]
            {
                newUser.userName,
                newUser.passWord,
                ConvertEnum(newUser)
            });
        }

        public void SetUser(string[] userFile)
        {
            try
            {
               Kernel.currentUser = new()
               {
                   userName = userFile[0],
                   passWord = userFile[1],
                   userElevation = ConvertString(userFile[2]),
               };
            }
            catch
            {
                Log.Log.ShowLog("usermgr: Failed to set user, Current user is now guest", Log.LogWarningLevel.Error);
                Kernel.currentUser = new()
                {
                    userName = "guest",
                    passWord = "guest",
                    userElevation = UserElevation.Guest,
                };
            }
        }

        public bool VerifyUser()
        {
            if (Kernel.currentUser == null)
            {
                Log.Log.ShowLog("Please logged into a user first!", Log.LogWarningLevel.Error);
            }
            else if (Kernel.currentUser.userElevation == UserElevation.Guest)
            {
                Log.Log.ShowLog("Please logged into a user first!", Log.LogWarningLevel.Error);
            }
            else
            {
                while (true)
                {
                    Console.Write($"[Verify] Enter {Kernel.currentUser.userName} password : ");
                    string passCheck = Console.ReadLine();
                    if (passCheck != Kernel.currentUser.passWord)
                    {
                        return false;
                    }
                    else if (passCheck == Kernel.currentUser.passWord)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void Login()
        {
            string[] userDir = Directory.GetDirectories(@"0:\System\User\");
            
            if (userDir.Length == 0)
            {
                Console.WriteLine("No user has been detected!, Please run \"sysprep\" to run system setup");
            }
            else
            {
                string usr;
                string psw;
                string[] userdata;

                while (true)
                {
                    Console.Write("[userlgn] Enter user name : ");
                    usr = Console.ReadLine();
                    Console.Write("[userlgn] Enter user password : ");
                    psw = Console.ReadLine();

                    if (!File.Exists($@"0:\System\User\{usr}\{usr}.usr"))
                    {
                        Log.Log.ShowLog("login: User doesnt exist", Log.LogWarningLevel.Error);
                        break;
                    }
                    else
                    {
                        try
                        {
                            userdata = File.ReadAllLines($@"0:\System\User\{usr}\{usr}.usr");
                            if (usr == userdata[0] && psw == userdata[1])
                            {
                                Kernel.currentUser = new User()
                                {
                                    userName = userdata[0],
                                    passWord = userdata[1],
                                    userElevation = ConvertString(userdata[2]),
                                };
                                Log.Log.ShowLog("login: User logged in", Log.LogWarningLevel.Information);
                                break;
                            }
                            else
                            {
                                Log.Log.ShowLog("Wrong password or username", Log.LogWarningLevel.Error);
                            }
                        }
                        catch
                        {
                            Log.Log.ShowLog("login: Error occured", Log.LogWarningLevel.Error);
                        }
                    }
                }
            }
        }

        public void ListUser()
        {
            for (int i = 0; i < Directory.GetFiles(@"0:\System\User\").Length; i++)
            {
                Console.WriteLine($"[{i}] {Path.GetFileName(Directory.GetFiles(@"0:\System\User\")[i])}");
            }
        }

        public string ConvertEnum(User user)
        {
            switch (user.userElevation)
            {
                case UserElevation.Guest:
                    return "Guest";
                case UserElevation.User:
                    return "User";
                case UserElevation.Root:
                    return "Root";
            }
            return "None";
        }

        public UserElevation ConvertString(string elevation)
        {
            switch (elevation)
            {
                case "Guest":
                    return UserElevation.Guest;
                case "User":
                    return UserElevation.User;
                case "Root":
                    return UserElevation.Root;
            }
            return UserElevation.Guest;
        }
    }
}
