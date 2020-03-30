using System;
using System.Collections.Generic;
using System.IO;
using ToyLanguage.Model.Type;
using ToyLanguage.Model.Value;

namespace ToyLanguage.Model.Statement.FileTablePack
{
    public class CloseFile: Statement
    {
        private Expression.Expression expression;

        public CloseFile(Expression.Expression expression)
        {
            this.expression = expression;
        }

        public ProgramState execute(ProgramState state)
        {
            if(!expression.evaluate(state.GetSymTable(), state.GetHeap()).GetTypeInter().HasSameType(new StringType()))
                throw new Exception("File name should be of String Type!\n");
            String val = ((StringValue) expression.evaluate(state.GetSymTable(), state.GetHeap())).GetValue();
            
            if(!state.GetFileTable().ContainsKey(val))
                throw new Exception("File "+val+" not registered!");
            FileStream fileStream = state.GetFileTable()[val];
            state.GetFileTable().TryRemove(val, out fileStream);
            fileStream.Close();
            return null;
        }

        public override string ToString()
        {
            return "closeFile(" + expression.ToString() + ")";
        }
    }
}