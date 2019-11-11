using System;
using Data.SOReferences;
using UnityEngine;
using UnityEngine.UI;

namespace GenericEventAndReferences.SOReferences.TextReference
{
    [Serializable]
    public class TextReference : Reference<Text,TextVariable>
    {
        public TextReference(Text Value) : base(Value)
        {
        }

        public TextReference()
        {
        }
    }
}
