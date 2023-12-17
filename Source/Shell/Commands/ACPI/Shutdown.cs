using Cosmos.System;
using System;

namespace BootNET.Shell.Commands.ACPI
{
    public class Shutdown : Command
    {
        public Shutdown(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            string response;
            try
            {
                Power.Shutdown();
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
