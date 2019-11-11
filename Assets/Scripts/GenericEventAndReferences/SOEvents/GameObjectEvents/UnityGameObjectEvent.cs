using System;
using UnityEngine;
using UnityEngine.Events;

namespace GenericEventAndReferences.SOEvents.GameObjectEvents
{
    [Serializable]
    public class UnityGameObjectEvent : UnityEvent<GameObject>
    {
    }
}