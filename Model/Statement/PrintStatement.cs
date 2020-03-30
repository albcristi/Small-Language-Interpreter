using System;

namespace ToyLanguage.Model.Statement
{
    public class PrintStatement: Statement
    {
        private Expression.Expression st;

        public PrintStatement(Expression.Expression st) => this.st = st;

        public override String ToString()
        {
            return "print(" + st.ToString() + ")";
        }

        public ProgramState execute(ProgramState state)
        {
            state.GetOut().Add(st.evaluate(state.GetSymTable(), state.GetHeap()));
            return null;
        }
    }
}