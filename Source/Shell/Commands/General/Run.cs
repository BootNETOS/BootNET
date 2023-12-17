namespace BootNET.Shell.Commands.General
{
    public class Run : Command
    {
        public Run(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            Batch.Execute(args[0]);
            return "";
        }
    }
}
