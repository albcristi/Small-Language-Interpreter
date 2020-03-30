using System;
using ToyLanguage.Model.Type;

namespace ToyLanguage.Model.Value
{
    public class IntValue : Value
    {
        private Int32 no;
        
        public IntValue(Int32 no) => this.no = no;

        public Int32 getValue()
        {
            return this.no;
        }

        public override string ToString()
        {
            return no.ToString();
        }

        public new Type.Type GetTypeInter()
        {
            return new IntType();
        }

       
    }
}