using System.Collections.Generic;
using UnityEngine;

namespace GenericEventAndReferences.SOReferences
{
    [CreateAssetMenu(fileName = "LetterBoxesList_Variable", menuName = "SOVariable/LettersBoxesList")]
    public class LetterBoxesListVariable : Variable<List<LettersBoxesComponent>>
    { }
}
