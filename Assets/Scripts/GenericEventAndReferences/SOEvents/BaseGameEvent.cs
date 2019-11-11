using System;
using System.Collections.Generic;
using UnityEngine;

namespace GenericEventAndReferences.SOEvents
{
    public abstract class BaseGameEvent<T> : ScriptableObject
    {
        private List<IGameEventListener<T>> _listeners = new List<IGameEventListener<T>>();

        [TextArea] public string Description;
        public int NumberOfListeners => _listeners.Count;

        
        [field: NonSerialized]
        public float NumberOfRaise { get; private set; }

        public void Raise(T item)
        {
            for (var i = _listeners.Count - 1; i >= 0; i--) _listeners[i].OnEventRaised(item);
            NumberOfRaise++;
        }

        public void RegisterListener(IGameEventListener<T> listener)
        {
            if (!_listeners.Contains(listener))
                _listeners.Add(listener);
        }

        public void UnregisterListener(IGameEventListener<T> listener)
        {
            if (_listeners.Contains(listener))
                _listeners.Remove(listener);
        }
    }
}