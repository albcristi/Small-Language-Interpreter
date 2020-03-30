using System;
using System.Collections.Concurrent;
using System.Net;
using ToyLanguage.DataStructures;
using ToyLanguage.Model.Type;
using ToyLanguage.Model.Value;

namespace ToyLanguage.Model.Expression
{
    public class RelationalExpression: Expression
    {
        private Expression expr1;
        private Expression expr2;
        private String operation;

        public RelationalExpression(Expression expr1, Expression expr2, string operation)
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
            Value.Value result = new BoolValue(false);
            
            if(!expr1.evaluate(symTable, heapTable).GetTypeInter().HasSameType(new IntType()) || 
               !expr2.evaluate(symTable, heapTable).GetTypeInter().HasSameType(new IntType()) )
                throw new Exception("Incompatible types for expressions!\n");

            Int32 v1 = ((IntValue) expr1.evaluate(symTable, heapTable)).getValue();
            Int32 v2 = ((IntValue) expr2.evaluate(symTable, heapTable)).getValue();
            switch (operation)
            {
                case ("=="):
                {
                    result = new BoolValue(v1==v2);
                    break;
                    
                }
                case (">="):
                {
                    result = new BoolValue(v1>=v2);
                    break;
                }
                case (">"):
                {
                    result = new BoolValue(v1>v2);
                    break;
                }
                case("<="):
                {
                    result = new BoolValue(v1<=v2) ;
                    break;
                }
                case ("<"):
                {
                    result = new BoolValue(v1<v2);
                    break;
                }
                default:
                    throw new Exception("Invalid operator given!");
            
            }

            return result;
        }
    }
}