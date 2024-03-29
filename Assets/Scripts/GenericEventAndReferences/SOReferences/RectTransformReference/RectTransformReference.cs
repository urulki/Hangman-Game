using System;
using Data.SOReferences;
using UnityEngine;

namespace GenericEventAndReferences.SOReferences.RectTransformReference
{
    [Serializable]
    public class RectTransformReference : Reference<RectTransform, RectTransformVariable>
    {
        public RectTransformReference(RectTransform Value) : base(Value)
        {
        }

        public RectTransformReference()
        {
        }
    }
}