using System;
using System.Collections.Concurrent;
using ToyLanguage.DataStructures;

namespace ToyLanguage.Model.Expression
{
    public class VariableExpression: Expression
    {
        private String id;

        public VariableExpression(string id)
        {
            this.id = id;
        }

        public override string ToString()
        {
            return id;
        }

        public Value.Value evaluate(ConcurrentDictionary<string, Value.Value> symTable, HeapInterface heapTable)
        {
            if(!symTable.ContainsKey(id))
                throw new Exception("Invalid variable name!\n");
            return symTable[id];
        }
    }
}