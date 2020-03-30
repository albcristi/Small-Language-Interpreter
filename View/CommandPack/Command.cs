namespace ToyLanguage.View.CommandPack
{
    public abstract class Command
    {
        private string key;
        private string description;

        public Command(string key, string description)
        {
            this.key = key;
            this.description = description;
        }

        public abstract void Execute();
        public string GetKey() { return key; }
        public string GetDescription() { return description; }
    }
}