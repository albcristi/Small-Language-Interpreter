using System;
using System.Collections.Concurrent;
using System.Dynamic;
using System.Net.Http.Headers;
using ToyLanguage.DataStructures;
using ToyLanguage.Model.Type;
using ToyLanguage.Model.Value;

namespace ToyLanguage.Model.Expression
{
    public class ArithmeticExpression : Expression
    {
        private Expression exp1;
        private Expression exp2;
        private String operation;

        public ArithmeticExpression(Expression exp1, Expression exp2, string operation)
        {
            this.exp1 = exp1;
            this.exp2 = exp2;
            this.operation = operation;
        }

        public override string ToString()
        {
            return exp1.ToString() + operation + exp2.ToString();
        }

        public Value.Value evaluate(ConcurrentDictionary<string, Value.Value> symTable, HeapInterface heapTable)
        {
            if(!(exp1.evaluate(symTable, heapTable).GetTypeInter().HasSameType(new IntType()))||
               !(exp2.evaluate(symTable, heapTable).GetTypeInter().HasSameType(new IntType())))
                throw new Exception("Invalid types: Arithmetic Expression Works only with INTS!\n");
            Int32 v1 = ((IntValue) exp1.evaluate(symTable, heapTable)).getValue();
            Int32 v2 = ((IntValue) exp2.evaluate(symTable, heapTable)).getValue();
            Int32 res;
            switch (operation)
            {
                case ("+"): {
                    res = v1 + v2;
                    break;
                }
                case ("-"): {
                    res = v1 - v2;
                    break;
                }
                case(":") : {
                    if(v2==0)
                        throw new Exception("DIVISION BY 0\n");
                    res=v1/v2 ;
                    break;
                }
                case ("*"):
                {
                    res = v1 * v2;
                    break;
                }
                default:
                    throw new Exception("Invalid operation: "+operation);
            }
            return  new IntValue(res);
        }
    }
}