using BootNET.Core;
using Cosmos.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootNET.Shell
{
    public class Batch
    {
        /// <summary>
        /// Execute batch-like script with ext .aus or .bat
        /// </summary>
        /// <param name="filename">Script file</param>
        public static void Execute(string filename)
        {
            try
            {
                if (filename.EndsWith(".bat"))
                {
                    string[] lines = File.ReadAllLines(filename);
                    foreach (string line in lines)
                    {
                        if (!(line.StartsWith(";")))// don't read the line if it start with ";" for comment
                        {
                            Program.commandManager.ExecuteCommand(line);
                        }
                    }
                }
                else
                {
                    
                }
            }
            catch ()
            {
            }

        }
    }
}