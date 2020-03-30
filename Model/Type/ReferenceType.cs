namespace ToyLanguage.Model.Type
{
    public class ReferenceType: Type
    {
        private Type innerType;

        public ReferenceType(Type innerType)
        {
            this.innerType = innerType;
        }

        public bool HasSameType(object obj)
        {
            if (obj is ReferenceType)
                return innerType.HasSameType(((ReferenceType) obj).getInner());
            return false;
        }

        public Value.Value DefaultValue()
        {
            throw new System.NotImplementedException();
        }

        public Type getInner()
        {
            return innerType;
        }

        public override string ToString()
        {
            return "ref(" + innerType.ToString() + ")";
        }
    }
}