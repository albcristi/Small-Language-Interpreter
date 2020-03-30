namespace ToyLanguage.Model.Type
{
    public interface Type
    {
        public bool HasSameType(object obj);
        Value.Value DefaultValue();
    }
}