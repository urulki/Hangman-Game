using System.Collections.Generic;
using UnityEngine;

namespace GenericEventAndReferences.SOReferences.GameObjectListReference
{
    [CreateAssetMenu(fileName = "GameObjectList_Variable", menuName = "SOVariable/GameObjectList")]
    public class GameObjectListVariable : Variable<List<GameObject>>
    {
    }
}