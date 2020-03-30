using System;
using ToyLanguage.Model.Type;

namespace ToyLanguage.Model.Value
{
    public class ReferenceValue: Value
    {

        private Int32 address;
        private Type.Type locationType;


        public ReferenceValue(int address, Type.Type locationType)
        {
            this.address = address;
            this.locationType = locationType;
        }

        public Type.Type GetTypeInter()
        {
            return new ReferenceType(locationType);
        }

        public override string ToString()
        {
            return "(" + address + "," + locationType.ToString() + ")";
        }

        public Int32 getAddress() => address;

        public Type.Type getInnerType() => locationType;
    }
}