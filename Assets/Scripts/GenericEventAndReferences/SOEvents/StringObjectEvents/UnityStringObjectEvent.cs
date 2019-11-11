using System;
using UnityEngine.Events;

namespace GenericEventAndReferences.SOEvents.StringObjectEvents
{
    [Serializable]
    public class UnityStringObjectEvent : UnityEvent<Tuple<string, object>>
    {
    }
}