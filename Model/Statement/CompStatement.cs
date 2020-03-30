using System;

namespace ToyLanguage.Model.Statement
{
    public class CompStatement : Statement
    {
        private Statement first;
        private Statement second;

        public CompStatement(Statement f, Statement s)
        {
            this.first = f;
            this.second = s;
        }

        public  override string ToString()
        {
            return "(" + first.ToString() + ";" + second.ToString() + ")";
        }

        public ProgramState execute(ProgramState state)
        {
            state.GetExeStack().Push(second);
            state.GetExeStack().Push(first);
            return null;
        }
    }
}