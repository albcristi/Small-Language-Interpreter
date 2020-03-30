using System;

namespace ToyLanguage.Model.Statement
{
    public class AssignStatement: Statement
    {
        private String id;
        private Expression.Expression expr;

        public AssignStatement(string id, Expression.Expression expr)
        {
            this.id = id;
            this.expr = expr;
        }

        public override string ToString()
        {
            return id + "=" + expr.ToString();
        }

        public ProgramState execute(ProgramState state)
        {
            if(!state.GetSymTable().ContainsKey(id))
                throw new Exception("Variable "+id+" is not defined!\n");
            
            if(!state.GetSymTable()[id].GetTypeInter().HasSameType(expr.evaluate(state.GetSymTable(), state.GetHeap()).GetTypeInter()))
                throw new Exception("Incompatible Assignment! Types Do Not Match!\n");

            state.GetSymTable()[id] = expr.evaluate(state.GetSymTable(), state.GetHeap());
            return null;
        }
    }
}