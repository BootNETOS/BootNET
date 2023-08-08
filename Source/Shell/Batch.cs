﻿using BootNET.Core;
using System;
using System.IO;

namespace BootNET.Shell
{
    public static class Batch
    {
        public static void Execute(string filename)
        {
            try
            {
                if (filename.EndsWith(".bat"))
                {
                    string[] lines = File.ReadAllLines(filename);
                    foreach (string line in lines)
                    {
                        if (!(line.StartsWith(";")))
                        {
                            string response = Terminal.CommandManager.ProcessInput(line);
                            Console.WriteLine(response);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("This file is not a valid script.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}