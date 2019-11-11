using System;
using Data.SOReferences;
using UnityEngine;

namespace GenericEventAndReferences.SOReferences.TransformReference
{
    [Serializable]
    public class TransformReference : Reference<Transform, TransformVariable>
    {
        public TransformReference(Transform Value) : base(Value)
        {
        }

        public TransformReference()
        {
        }
    }
}