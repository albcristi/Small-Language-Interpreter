using System;
using ToyLanguage.DataStructures;
using ToyLanguage.Model.Type;
using ToyLanguage.Model.Value;

namespace ToyLanguage.Model.Statement.HeapPack
{
    public class WriteHeap: Statement
    {
        private String var;
        private Expression.Expression expr;

        public WriteHeap(string @var, Expression.Expression expr)
        {
            this.var = var;
            this.expr = expr;
        }

        public override string ToString()
        {
            return "writeHeap(" + var + "," + expr + ")";
        }

        public ProgramState execute(ProgramState state)
        {
            /*
             * it is a statement which takes a variable and an expression, the variable contains the heap
                address, the expression represents the new value that is going to be stored into the heap
            • first we check if var_name is a variable defined in SymTable, if its type is a Ref type and if
                the address from the RefValue associated in SymTable is a key in Heap. If not, the execution
                is stopped with an appropriate error message.*/
            if(!state.GetSymTable().ContainsKey(this.var))
                throw new Exception("Variable "+this.var+" is not registered!\n");
            
            if(!(state.GetSymTable()[this.var] is ReferenceValue))
                throw new Exception("Not a reference type found for var: "+this.var);

            Int32 address = ((ReferenceValue) state.GetSymTable()[this.var]).getAddress();
            
            if(!((Heap) state.GetHeap()).ContainsKey(address))
                throw new Exception("Invalid address!\n");
            /*
                • Second the expression is evaluated and the result must have its type equal to the
                locationType of the var_name type. If not, the execution is stopped with an appropriate
                message.*/
            Value.Value val = expr.evaluate(state.GetSymTable(), state.GetHeap());
            
            /*
                • Third we access the Heap using the address from var_name and that Heap entry is updated
                to the result of the expression evaluation.
             */
            ((Heap) state.GetHeap())[address] = val;
            return null;
        }
    }
}