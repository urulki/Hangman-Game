﻿using System;
using UnityEngine;

namespace GenericEventAndReferences.SOEvents.StringObjectEvents
{
    [CreateAssetMenu(fileName = "StringObjectTuple_OnEvent", menuName = "SOEvent/StringObjectTuple")]
    public class StringObjectEvent : BaseGameEvent<Tuple<string, object>>
    {
    }
}