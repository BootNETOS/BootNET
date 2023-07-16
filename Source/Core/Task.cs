using System;

namespace BootNet.Core
{
    public class Task
    {
        public string Name, Description;
        public uint ProcessID;
        public Action Action;
        public bool IsRunning, Critical;
        public Task(string name, string description, uint processID, Action action = null, bool running = true, bool critical = false)
        {
            this.Name = name;
            this.Description = description;
            this.ProcessID = processID;
            this.Action = action;
            this.IsRunning = running;
            this.Critical = critical;
        }
        public void Update()
        {
            if (IsRunning)
            {
                Run();
            }
        }
        public virtual void Run()
        {
            Action?.Invoke();
        }
        public void Stop()
        {
            if (IsRunning)
            {
                IsRunning = false;
            }
        }
    }
}
