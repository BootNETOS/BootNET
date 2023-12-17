using Cosmos.System;
using System;

namespace BootNET.Shell.Commands.ACPI
{
    public class Reboot : Command
    {
        public Reboot(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            string response;
            try
            {
                Power.Reboot();
                response = "";
            }
            catch (Exception ex)
            {
                response = "Error: " + ex.Message;
            }
            return response;
        }
    }
}
