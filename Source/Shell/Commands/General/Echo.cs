namespace BootNET.Shell.Commands.General
{
    public class Echo : Command
    {
        public Echo(string name) : base(name) { }
        public override string Invoke(string[] args)
        {
            string response = "";
            foreach (var item in args)
            {
                response = item + " ";
            }
            return response;
        }
    }
}
