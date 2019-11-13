using GenericEventAndReferences.SOReferences.StringReference;
using GenericEventAndReferences.SOReferences.TextReference;
using UnityEngine;
using UnityEngine.UI;

namespace Letters
{
    public class WrongLetterComponent : MonoBehaviour
    {
        
        public StringVariable WrongLetters;
        public void UpdateText()
        {
            GetComponent<Text>().text = WrongLetters.Value;
        }
    }
}
