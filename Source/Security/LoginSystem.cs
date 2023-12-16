using BootNET.Core;
using System;
using System.Collections.Generic;
using System.IO;
using Kernel = BootNET.Core.Program;

namespace BootNET.Security
{
    class LoginSystem
    {
        public static void Login()
        {
            Dictionary<string, string> users = new();

            if (BootNET.Core.BootManager.FilesystemEnabled == true & Directory.Exists(@"0:\Users\"))
            {
                var dir_list = Directory.GetDirectories(@"0:\Users\");
                foreach (var dir in dir_list)
                {
                    if (File.Exists(@"0:\Users\" + dir + @"\password.cfg"))
                        users.Add(dir.ToString(), File.ReadAllText(@"0:\Users\" + dir + @"\password.cfg"));
                }
            }
            else
            {
                users.Add("root", "password");
            }

            Console.Write("username: ");
            string username = Console.ReadLine();
            Console.Write("password: ");
            string password = Console.ReadLine();

            if (users.ContainsKey(username) && users[username] == password)
            {
                Console.WriteLine("Login successful!");
                Kernel.Username = username;
                Kernel.LoggedIn = true;
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
            }
        }
        public static void Setup()
        {
            Console.WriteLine();
            Console.Write("Username: ");
            var username = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();
            try
            {
                if (Directory.Exists(@"0:\Users\")) { }
                else
                {
                    BootManager.FilesystemDriver.CreateDirectory(@"0:\Users\");
                }
                BootManager.FilesystemDriver.CreateDirectory(@"0:\Users\" + username + "\\");
                BootManager.FilesystemDriver.CreateFile(@"0:\Users\" + username + @"\password.cfg");
                File.WriteAllText(@"0:\Users\" + username + @"\password.cfg", password);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public static void Remove()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Warning: if you remove the only user in disk 0:\\, you will not be able to use this os if you reboot. Please pay attention.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Username: ");
            var username = Console.ReadLine();
            try
            {
                Directory.Delete(@"0:\Users\" + username);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public static void CreateHome()
        {
            Console.WriteLine();
            Console.Write("Username: ");
            var username = Console.ReadLine();
            try
            {
                BootManager.FilesystemDriver.CreateDirectory(@"0:\Users\" + username + @"\home\");
                BootManager.FilesystemDriver.CreateDirectory(@"0:\Users\" + username + @"\home\Documents\");
                BootManager.FilesystemDriver.CreateDirectory(@"0:\Users\" + username + @"\home\Images\");
                BootManager.FilesystemDriver.CreateDirectory(@"0:\Users\" + username + @"\home\Scripts\");
                BootManager.FilesystemDriver.CreateDirectory(@"0:\Users\" + username + @"\home\Desktop\");
                BootManager.FilesystemDriver.CreateDirectory(@"0:\Users\" + username + @"\home\Music\");
                BootManager.FilesystemDriver.CreateDirectory(@"0:\Users\" + username + @"\home\Downloads\");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}