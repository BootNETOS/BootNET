using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootNET.Shell
{
    public class PackageCommand : Command
    {
        public PackageCommand(string name, string description, Action<string> path) : base(new[] {name})
        {

        }
        public override void Execute()
        {
            
        }
    }
}
