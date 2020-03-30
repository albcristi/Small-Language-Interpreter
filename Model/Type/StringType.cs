using ToyLanguage.Model.Value;

namespace ToyLanguage.Model.Type
{
    public class StringType: Type
    {
        public  bool HasSameType(object? obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Type))
                return false;
            var t = (Type) obj;

            return t is StringType;
        }


        public override string ToString()
        {
            return "string";
        }

        public Value.Value DefaultValue()
        {
            return new StringValue("");
        }
    }
}