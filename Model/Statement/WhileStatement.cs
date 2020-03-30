
using System;
using Microsoft.VisualBasic.CompilerServices;
using ToyLanguage.Model.Type;
using ToyLanguage.Model.Value;

namespace ToyLanguage.Model.Statement
{
    public class WhileStatement: Statement
    {
        private Expression.Expression cond;
        private Statement body;

        public WhileStatement(Expression.Expression cond, Statement body)
        {
            this.cond = cond;
            this.body = body;
        }

        public override string ToString()
        {
            return "while(" + cond + ") do {" + body + "}";
        }

        public ProgramState execute(ProgramState state)
        {
            if(!cond.evaluate(state.GetSymTable(),state.GetHeap()).GetTypeInter().HasSameType(new BoolType()))
                throw new Exception("Invalid While Condition!\n");

            if (!((BoolValue) cond.evaluate(state.GetSymTable(), state.GetHeap())).getValue())
                return null;
            
            state.GetExeStack().Push(this);
            state.GetExeStack().Push(body);
            return null;
        }
    }
}