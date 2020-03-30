using System;
using ToyLanguage.Model.Value;

namespace ToyLanguage.Model.Type
{
    public class IntType : Type
    {
        public bool HasSameType(object obj)
        {
            if (obj == null)
                return false;

            if (obj is IntType)
                return true;
            return false;
        }

        public override string ToString()
        {
            return "int";
        }

        public Value.Value DefaultValue()
        {
            return new IntValue(0);
        }
    }
}