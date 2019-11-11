using System;
using GenericEventAndReferences.SOReferences.StringReference;
using Management;
using UnityEngine;
using UnityEngine.UI;

namespace Letters
{
    public class LettersButtonsComponent : MonoBehaviour
    {
        private Button currentBtn;
        public StringVariable LinkedLetter;
        
        // Start is called before the first frame update
        void Awake()
        {
            currentBtn = GetComponent<Button>();
        }

        private void OnEnable()
        {
            currentBtn.name = LinkedLetter.Value;
            currentBtn.GetComponentInChildren<Text>().text = LinkedLetter.Value;
        }
    }
}
