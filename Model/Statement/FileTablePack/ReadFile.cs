using System;
using System.IO;
using ToyLanguage.Model.Type;
using ToyLanguage.Model.Value;

namespace ToyLanguage.Model.Statement.FileTablePack
{
    public class ReadFile: Statement
    {
        private Expression.Expression expression;
        private String var;


        public ReadFile(Expression.Expression expression, string var)
        {
            this.expression = expression;
            this.var = var;
        }

        public override string ToString()
        {
            return "readFile(" + expression.ToString() + "," + var + ")";
        }

        public ProgramState execute(ProgramState state)
        {
            if(!state.GetSymTable().ContainsKey(var))
                throw new Exception("Variable: "+var+" not registered!\n");
            if(!state.GetSymTable()[var].GetTypeInter().HasSameType(new IntType()))
                throw new Exception("Type of variable should be IntType!\n");
            
            if(!expression.evaluate(state.GetSymTable(), state.GetHeap()).GetTypeInter().HasSameType(new StringType()))
                throw new Exception("Expression should reduce to StringValue!\n");
            if(!state.GetFileTable().ContainsKey(((StringValue)expression.evaluate(state.GetSymTable(), state.GetHeap())).GetValue()))
                throw new Exception("File "+expression.ToString()+" not registered!\n");

            FileStream fileStream =
                state.GetFileTable()[((StringValue) expression.evaluate(state.GetSymTable(), state.GetHeap())).GetValue()];
            StreamReader streamReader = new StreamReader(fileStream);
            String line = streamReader.ReadLine();

            if (line == null) 
                state.GetSymTable()[var]=new IntValue(0);
            else
            {
                state.GetSymTable()[var]=new IntValue(Int32.Parse(line));
            }
            return null;
        }
    }
}