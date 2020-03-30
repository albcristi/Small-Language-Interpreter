namespace ToyLanguage.Model.Statement
{
    public class NopStatement: Statement
    {
        public NopStatement()
        {
        }

        public override string ToString()
        {
            return "nop;";
        }

        public ProgramState execute(ProgramState state)
        {
            return null;
        }
    }
}