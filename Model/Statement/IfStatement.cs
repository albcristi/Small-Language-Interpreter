using System;
using System.Runtime.CompilerServices;
using ToyLanguage.Model.Type;
using ToyLanguage.Model.Value;

namespace ToyLanguage.Model.Statement
{
    public class IfStatement: Statement
    {
        private Expression.Expression expr;
        private Statement thenStat;
        private Statement elseStat;

        public IfStatement(Expression.Expression expr, Statement thenSt, Statement elseSt)
        {
            this.expr = expr;
            this.thenStat = thenSt;
            this.elseStat = elseSt;
        }

        public override string ToString()
        {
            return "if(" + expr.ToString() + ")then (" + thenStat.ToString() + ") else(" + elseStat.ToString() + ")";
        }

        public ProgramState execute(ProgramState state)
        {
            Console.WriteLine(expr.evaluate(state.GetSymTable(), state.GetHeap()).GetTypeInter());
            if(!(expr.evaluate(state.GetSymTable(), state.GetHeap()).GetTypeInter().HasSameType(new BoolType())))
                throw new Exception("Invalid If Statement!\n");
            Boolean val = ((BoolValue) expr.evaluate(state.GetSymTable(), state.GetHeap())).getValue();

            if (!val)
                state.GetExeStack().Push(elseStat);
            else
                state.GetExeStack().Push(thenStat);

            return null;
        }
    }
}