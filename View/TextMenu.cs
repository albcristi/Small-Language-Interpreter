using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using ToyLanguage.View.CommandPack;

namespace ToyLanguage.View
{
    public class TextMenu
    {
        private ConcurrentDictionary<String, Command> commands;
        public TextMenu(ConcurrentDictionary<string, Command> commands) => this.commands = commands;

        public void addCommand(Command cmd) => this.commands[cmd.GetKey()] = cmd;

        public void showTextMenu()
        {
            foreach (Command com in commands.Values)
                Console.WriteLine(String.Format("{0}: {1}", com.GetKey(), com.GetDescription()));
        }

        public void runTextMenu()
        {
            while (true)
            {
                showTextMenu();
                String cmd = Console.ReadLine();
                if (cmd == null)
                {
                    Console.WriteLine("Invalid Command!\n");
                    continue;
                }
                Command userCommand = commands[cmd];
                userCommand.Execute();
            }
        }
    }
}