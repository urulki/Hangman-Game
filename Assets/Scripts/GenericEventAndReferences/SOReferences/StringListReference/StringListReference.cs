using System;
using System.Collections.Generic;
using Data.SOReferences;
using UnityEngine;

namespace GenericEventAndReferences.SOReferences.StringListReference
{
    [Serializable]
    public class StringListReference : Reference<List<string>, StringListVariable>
    {
        public StringListReference(List<string> value) : base(value)
        {
            
        }

        public StringListReference()
        {
            
        }
        
    }
}
