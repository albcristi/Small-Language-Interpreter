using ToyLanguage.Model.Value;

namespace ToyLanguage.Model.Type
{
    public class BoolType:Type
    {
        public  bool HasSameType(object obj)
        {
            if (obj == null)
                return false;
            if (obj is BoolType)
                return true;
            return false;
        }

        public override string ToString()
        {
            return "boolean";
        }

        public Value.Value DefaultValue()
        {
            return new BoolValue(false);
        }
    }
}