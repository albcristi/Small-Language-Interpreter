using System;
using ToyLanguage.Model.Type;
using ToyLanguage.Model.Value;

namespace ToyLanguage.Model.Statement
{
    public class VarDeclStatement : Statement
    {
        private String id;
        private Type.Type type;

        public VarDeclStatement(string id, Type.Type type)
        {
            this.id = id;
            this.type = type;
        }

        public override string ToString()
        {
            return type.ToString() + " " + id;
        }

        public ProgramState execute(ProgramState state)
        {
            if(state.GetSymTable().ContainsKey(id))
                throw new Exception("Variable already declared!\n");
            Value.Value val = null;
            if(type.HasSameType(new IntType()))
                val=new IntValue(0);
            else if(type.HasSameType(new BoolType()))
                val=new BoolValue(false);
            else if (type.HasSameType(new StringType()))
                val = new StringValue("");
            else
            {
                val = new ReferenceValue(0, ((ReferenceType) type).getInner());
            }
            state.GetSymTable()[id] = val;
            
            return null;
        }
    }
}