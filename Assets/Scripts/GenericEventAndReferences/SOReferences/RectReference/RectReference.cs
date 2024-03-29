using System;
using Data.SOReferences;
using UnityEngine;

namespace GenericEventAndReferences.SOReferences.RectReference
{
    [Serializable]
    public class RectReference : Reference<Rect, RectVariable>
    {
        public RectReference(Rect Value) : base(Value)
        {
        }

        public RectReference()
        {
        }
    }
}