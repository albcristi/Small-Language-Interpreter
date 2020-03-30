using System;

namespace ToyLanguage.View.CommandPack
{
    public class ExitCommand: Command
    {
        public ExitCommand(string key, string description) : base(key, description)
        {
        }

        public override void Execute()
        {
            Console.WriteLine("-------END OF PROGRAM EXECUTION------");
            Environment.Exit(0);
        }
    }
}