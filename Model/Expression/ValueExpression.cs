using System;
using System.Collections.Concurrent;
using ToyLanguage.DataStructures;

namespace ToyLanguage.Model.Expression
{
    public class ValueExpression: Expression
    {
        private Value.Value val;

        public ValueExpression(Value.Value val)
        {
            this.val = val;
        }

        public Value.Value evaluate(ConcurrentDictionary<string, Value.Value> symTable, HeapInterface heapTable)
        {
            return val;
        }

        public override string ToString()
        {
            return val.ToString();
        }
    }
}