using System;
using System.Collections.Concurrent;
using ToyLanguage.DataStructures;
using ToyLanguage.Model.Type;
using ToyLanguage.Model.Value;

namespace ToyLanguage.Model.Expression
{
    public class LogicExpression: Expression
    {
        private Expression expr1;
        private Expression expr2;
        private String operation;

        public LogicExpression(Expression expr1, Expression expr2, string operation)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
            this.operation = operation;
        }

        public override string ToString()
        {
            return expr1.ToString() + operation + expr2.ToString();
        }

        public Value.Value evaluate(ConcurrentDictionary<string, Value.Value> symTable, HeapInterface heapTable)
        {
            if(!(expr1.evaluate(symTable, heapTable).GetTypeInter().HasSameType(new BoolType()))||
               !(expr2.evaluate(symTable, heapTable).GetTypeInter().HasSameType(new BoolType())))
                throw new Exception("INVALID TYPES FOR LOGIC EXPRESSION!\n");

            Boolean b1 = ((BoolValue) expr1.evaluate(symTable, heapTable)).getValue();
            Boolean b2 = ((BoolValue) expr2.evaluate(symTable, heapTable)).getValue();
            Boolean b3 = false;

            if (operation == "&")
                b3 = b1 & b2;
            else if (operation == "||")
                b3 = b1 || b2;
            else
            {
                throw new Exception("Invalid logic operation!\n");
            }
            return new BoolValue(b3);
        }
    }
}