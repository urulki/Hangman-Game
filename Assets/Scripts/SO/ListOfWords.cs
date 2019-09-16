using System;
using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "List Of Words", menuName = "Words/List Of Words")]
    public class ListOfWords : ScriptableObject
    {
        public List<String> WordsToFind = new List<string>();
    }
}
