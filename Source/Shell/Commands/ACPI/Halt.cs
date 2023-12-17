using Cosmos.Core;
using System;

namespace BootNET.Shell.Commands.ACPI
{
    public class Halt : Command
    {
        public Halt(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            string response;
            try
            {
                CPU.Halt();
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
