using System;
using System.Collections.Generic;

namespace BootNET.Shell
{
    public class Command
    {
        #region Constructors
        /// <summary>
        /// Command class, used to make shell working.
        /// </summary>
        /// <param name="commandvalues">Command Values.</param>
        public Command(string[] commandvalues, Action action = null)
        {
            CommandValues = commandvalues;
            this.action = action;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Execution without arguments.
        /// </summary>
        public virtual void Execute()
        {
            action?.Invoke();
        }

        /// <summary>
        /// Execution with arguments.
        /// </summary>
        /// <param name="args">Arguments to pass.</param>
        public virtual void Execute(List<string> args) { }

        /// <summary>
        /// Help argument, used to get help for the user.
        /// </summary>
        public virtual void Help() { }

        /// <summary>
        /// Does the input corresponds to a command?
        /// </summary>
        /// <param name="command">Input.</param>
        /// <returns>true if the input equals the command, else false.</returns>
        public bool ContainsCommand(string command)
        {
            foreach (var commandvalue in CommandValues)
                if (commandvalue == command)
                    return true;
            return false;
        }
        #endregion

        #region Fields
        public string[] CommandValues;
        public Action action;
        #endregion
    }
}