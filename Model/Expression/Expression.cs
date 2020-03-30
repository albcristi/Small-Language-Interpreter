using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using ToyLanguage.DataStructures;

namespace ToyLanguage.Model.Expression
{
    public interface Expression
    {
        Value.Value evaluate(ConcurrentDictionary<string, Value.Value> symTable, HeapInterface heapTable);
    }
}