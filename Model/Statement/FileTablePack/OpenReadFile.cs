using System;
using System.IO;
using ToyLanguage.Model.Type;
using ToyLanguage.Model.Value;

namespace ToyLanguage.Model.Statement.FileTablePack
{
    public class OpenReadFile: Statement
    {
        private Expression.Expression expression;

        public OpenReadFile(Expression.Expression expression)
        {
            this.expression = expression;
        }

        public override string ToString()
        {
            return "openReadFile(" + expression.ToString() + ")";
        }

        public ProgramState execute(ProgramState state)
        {
            if(!expression.evaluate(state.GetSymTable(), state.GetHeap()).GetTypeInter().HasSameType(new StringType()))
                throw new Exception("Invalid value for expression, String Type needed!");
            String val = ((StringValue) expression.evaluate(state.GetSymTable(), state.GetHeap())).GetValue();
            
            if(state.GetFileTable().ContainsKey(val))
                throw new Exception("File already registered!");

            state.GetFileTable()[val] = File.OpenRead(val);
            return null;
        }
    }
}