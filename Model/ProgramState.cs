using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ToyLanguage.DataStructures;

namespace ToyLanguage.Model
{
    public class ProgramState
    {
        private Stack<Statement.Statement> executionStack;
        private ConcurrentDictionary<String, Value.Value> symbolTable;
        private List<Value.Value> outTable;
        private Statement.Statement origProgram;
        private ConcurrentDictionary<String, FileStream> fileTable;
        private HeapInterface heapTable;

        public ProgramState(Stack<Statement.Statement> executionStack,
            ConcurrentDictionary<string, Value.Value> symbolTable, List<Value.Value> outTable, Statement.Statement st)
        {
            this.executionStack = executionStack;
            this.symbolTable = symbolTable;
            this.outTable = outTable;
            this.origProgram = st;
            this.executionStack.Push(st);
            fileTable=new ConcurrentDictionary<string, FileStream>();
            heapTable=new Heap();
        }

        public Stack<Statement.Statement> GetExeStack() => executionStack;

        public ConcurrentDictionary<String, Value.Value> GetSymTable() => symbolTable;

        public List<Value.Value> GetOut() => outTable;

        public HeapInterface GetHeap() => heapTable;
        
        public ConcurrentDictionary<String, FileStream> GetFileTable() => fileTable;
        public override string ToString()
        {
            String s = "ExecutionStack: \n";

            foreach (Statement.Statement el in executionStack)
                s = s + el.ToString() + "\n";

            s = s + "SymbolTabel\n";
            foreach (KeyValuePair<String, Value.Value> p in symbolTable)
                s = s + p.Key + "=" + p.Value + "\n";
            s = s + "OutTable\n";
            foreach (Value.Value v in outTable)
                s = s + v.ToString() + " ";
            s += "\nFileTable:\n";
            foreach (KeyValuePair<String, FileStream> keyValuePair in fileTable)
                s += keyValuePair.Key + "-->" + keyValuePair.Value.ToString() + "\n";
            s += "HeapTable:\n";
            foreach (var keyval in (Heap) heapTable)
                s += keyval.Key + "-->" + keyval.Value + "\n";
            return s;
        }
    }
}
