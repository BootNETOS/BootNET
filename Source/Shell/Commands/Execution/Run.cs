using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootNET.Shell.Commands.Execution
{
    public class Run : Command
    {
        public Run(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            try
            {
                Batch.Execute(args[0]);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
            return "";
        }
    }
}
