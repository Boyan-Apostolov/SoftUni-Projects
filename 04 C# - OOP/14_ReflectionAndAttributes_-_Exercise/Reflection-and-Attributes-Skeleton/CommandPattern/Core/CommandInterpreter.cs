using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_POSTFIX = "Command";
        public CommandInterpreter()
        {
            
        }
        public string Read(string args)
        {
            string[] commandTokens = args.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string commandName = commandTokens[0]+COMMAND_POSTFIX;
            string[] commandArguments = commandTokens.Skip(1).ToArray();
            
            Assembly assembly = Assembly.GetCallingAssembly();
            Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == commandName.ToLower());

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            ICommand commandInstance = (ICommand) Activator.CreateInstance(commandType);
            string result = commandInstance.Execute(commandArguments);
            return result;
        }
    }
}
