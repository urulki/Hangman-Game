using System;
using Data.SOReferences;

namespace GenericEventAndReferences.SOReferences.StringReference
{
    [Serializable]
    public class StringReference : Reference<string, StringVariable>
    {
        public StringReference(string Value) : base(Value)
        {
        }

        public StringReference()
        {
        }
    }
}