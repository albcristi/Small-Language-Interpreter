using System;
using ToyLanguage.ControllerPack;

namespace ToyLanguage.View.CommandPack
{
    public class RunCommand: Command
    {
        private ControllerInterface contr;

        public RunCommand(string key, string description,ControllerInterface contr) : base(key, description)
        {
            this.contr = contr;
        }

        public override void Execute()
        {
            try
            {
                contr.allStep();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}