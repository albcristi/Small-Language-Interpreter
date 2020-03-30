using System;
using ToyLanguage.DataStructures;
using ToyLanguage.Model.Type;
using ToyLanguage.Model.Value;

namespace ToyLanguage.Model.Statement.HeapPack
{
    public class NewStatement: Statement
    {
        private Expression.Expression expr;
        private String var;

        public NewStatement(Expression.Expression expr, string @var)
        {
            this.expr = expr;
            this.var = var;
        }

        public ProgramState execute(ProgramState state)
        {
            /*
             it is a statement which takes a variable name and an expression
            • check whether var_name is a variable in SymTable and its type is a RefType. If not, the
            execution is stopped with an appropriate error message.*/
            if(!state.GetSymTable().ContainsKey(var))
                throw new Exception("Variable "+var+" is not declared!\n");
            
            if(!(state.GetSymTable()[var].GetTypeInter() is ReferenceType))
                throw new Exception("The type of the variable "+var+" has to be of Reference Type!\n");
            /*
            • Evaluate the expression to a value and then compare the type of the value to the
            locationType from the value associated to var_name in SymTable. If the types are not equal,
            the execution is stopped with an appropriate error message.*/
            Value.Value val = expr.evaluate(state.GetSymTable(), state.GetHeap());
            Type.Type t1 = ((ReferenceValue) state.GetSymTable()[var]).getInnerType();
            if(!val.GetTypeInter().HasSameType(t1))
                throw new Exception("Incompatible types!\n");
            /*
            • Create a new entry in the Heap table such that a new key (new free address) is generated and
            it is associated to the result of the expression evaluation*/
            Int32 generatedAddress = state.GetHeap().generateAddress();
            ((Heap) state.GetHeap()).TryAdd(generatedAddress, val);
            /*
            • in SymTable update the RefValue associated to the var_name such that the new RefValue
            has the same locationType and the address is equal to the new key generated in the Heap at
            the previous step
             */
            state.GetSymTable()[var]=new ReferenceValue(generatedAddress,val.GetTypeInter());
            return null;
        }

        public override string ToString()
        {
            return "new(" + var + "," + expr.ToString() + ")";
        }
    }
}