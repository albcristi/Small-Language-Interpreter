using System;
using System.Collections.Concurrent;
using ToyLanguage.DataStructures;
using ToyLanguage.Model.Value;

namespace ToyLanguage.Model.Expression
{
    public class ReadHeapExpr: Expression
    {
        private Expression expression;

        public ReadHeapExpr(Expression expression)
        {
            this.expression = expression;
        }

        public Value.Value evaluate(ConcurrentDictionary<string, Value.Value> symTable, HeapInterface heapTable)
        {
            /*
             • the expression must be evaluated to a RefValue. If not, the execution is stopped with an
            appropriate error message.
            • Take the address component of the RefValue computed before and use it to access Heap
            table and return the value associated to that address. If the address is not a key in Heap table,
            the execution is stopped with an appropriate error message.
             */
            if(!(expression.evaluate(symTable,heapTable) is ReferenceValue))
                throw new Exception("Evaluation of expression: "+expression+" should result in a Reference Value!\n");

            Int32 address = ((ReferenceValue) expression.evaluate(symTable, heapTable)).getAddress();
            
            if(!((Heap) heapTable).ContainsKey(address))
                throw new Exception("Invalid Heap Address!\n");
            return ((Heap) heapTable)[address];
        }

        public override string ToString()
        {
            return "readHeap(" + expression + ")";
        }
    }
}