namespace BootNET.Shell.Commands
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
