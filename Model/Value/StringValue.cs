using System;
using ToyLanguage.Model.Type;

namespace ToyLanguage.Model.Value
{
    public class StringValue: Value
    {
        private String val;

        public StringValue(string val)
        {
            this.val = val;
        }

        public override string ToString()
        {
            return "'" + val + "'";
        }

        public String GetValue() => val;
        public Type.Type GetTypeInter()
        {
            return new StringType();
        }
    }
}