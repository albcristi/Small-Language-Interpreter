using System;
using ToyLanguage.Model.Type;

namespace ToyLanguage.Model.Value
{
    public class BoolValue : Value
    {
        private Boolean val;

        public BoolValue(Boolean b) => val = b;
        
        public new Type.Type GetTypeInter()
        {
            return new BoolType();
        }

        public override string ToString()
        {
            return val.ToString();
        }

        public Boolean getValue() => val;
    }
}