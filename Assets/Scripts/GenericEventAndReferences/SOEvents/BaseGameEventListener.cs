using UnityEngine;
using UnityEngine.Events;

namespace GenericEventAndReferences.SOEvents
{
    public abstract class BaseGameEventListener<T, E, UE> : MonoBehaviour, IGameEventListener<T>
        where E : BaseGameEvent<T> where UE : UnityEvent<T>
    {
        public E GameEvent;
        public UE Response;

        public void OnEventRaised(T item)
        {
            Response.Invoke(item);
        }

        private void OnEnable()
        {
            GameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            GameEvent.UnregisterListener(this);
        }
    }
}