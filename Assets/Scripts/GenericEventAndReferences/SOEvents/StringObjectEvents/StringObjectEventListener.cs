using System;

namespace GenericEventAndReferences.SOEvents.StringObjectEvents
{
    public class
        StringObjectEventListener : BaseGameEventListener<Tuple<string, object>, StringObjectEvent,
            UnityStringObjectEvent>
    {
    }
}