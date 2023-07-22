using System.Collections.Generic;

namespace BootNET.Core
{
    public static class TaskManager
    {
        public static List<Task> TaskList { get; set; } = new();
        public static void RegisterProcess(Task task)
        {
            if (!TaskList.Contains(task))
                TaskList.Add(task);
        }
        public static void StopProcess(Task task)
        {
            if (TaskList.Contains(task))
                task.Stop();
        }
        public static void StopAll()
        {
            foreach (var task in TaskList)
                task.Stop();
        }
        public static void UnregisterProcess(Task task)
        {
            if (TaskList.Contains(task))
            {
                TaskList.Remove(task);
            }
        }
        public static uint GetProcessID(Task task)
        {
            if (TaskList.Contains(task))
            {
                return task.ProcessID;
            }
            else
            {
                throw new System.Exception("Task not registered!");
            }
        }
        public static Task GetTask(uint processID)
        {
            foreach (var task in TaskList)
            {
                if (task.ProcessID == processID) return task;
            }
            return null;
        }
        public static void Update()
        {
            foreach (var task in TaskList)
            {
                task.Update();
            }
        }
    }
}
