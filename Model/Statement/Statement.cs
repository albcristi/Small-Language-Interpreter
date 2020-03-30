namespace ToyLanguage.Model.Statement
{
    public interface Statement
    {
        ProgramState execute(ProgramState state);
    }
}