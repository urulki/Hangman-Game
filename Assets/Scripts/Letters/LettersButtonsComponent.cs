using System;
using System.Runtime.CompilerServices;
using GenericEventAndReferences.SOEvents.VoidEvents;
using GenericEventAndReferences.SOReferences;
using GenericEventAndReferences.SOReferences.BoolReference;
using GenericEventAndReferences.SOReferences.ButtonListReference;
using GenericEventAndReferences.SOReferences.StringReference;
using GenericEventAndReferences.SOReferences.TextListReference;
using GenericEventAndReferences.SOReferences.TextReference;
using Management;
using UnityEngine;
using UnityEngine.UI;

namespace Letters
{
    public class LettersButtonsComponent : MonoBehaviour
    {
        private Button currentBtn;
        
        public StringVariable LinkedLetter;
        public StringVariable WrongLet;
        public StringVariable SelectedWord;
        
        public TextVariable WLHandler;

        public LetterBoxesListVariable LettersBoxes;
        public StringVariable FirstLetter;
        
        public BoolVariable SetupComplete;

        public VoidEvent onLetterCheck;

        public VoidEvent onWrongLetter;

        public VoidEvent onDrawFinish;
        // Start is called before the first frame update
        void Awake()
        {
            currentBtn = GetComponent<Button>();
            currentBtn.interactable = true;
        }

        private void Update()
        {
            if (SetupComplete)
            {
                if (currentBtn.name == FirstLetter.Value) UnactiveLetButton(currentBtn);
                SetupComplete.Value = false;
            }
        }

        public void UnactiveLetButton(Button but)
        {
            if(currentBtn.interactable)currentBtn.interactable = false;
        }
        
        public void DrawWL(Button b)
        {
            if (!WrongLet.Value.Contains(b.GetComponent<LettersButtonsComponent>().LinkedLetter.Value) && 
                !SelectedWord.Value.Contains(b.GetComponent<LettersButtonsComponent>().LinkedLetter.Value))
            {
                WrongLet.Value += b.GetComponent<LettersButtonsComponent>().LinkedLetter.Value;
                onWrongLetter.Raise();
                UnactiveLetButton(GetComponent<Button>());
            }
        }
        
        public void CheckLetter(Button but)
        {
            foreach (var letBox in LettersBoxes.Value)
            {
                if (LinkedLetter.Value == letBox.GetComponent<LettersBoxesComponent>().LinkedLetter.ToString())
                {
                    onLetterCheck.Raise();
                    UnactiveLetButton(but);
                }
                else DrawWL(but);
            }
            onDrawFinish.Raise();
        }

        private void OnEnable()
        {
            currentBtn.name = LinkedLetter.Value;
            currentBtn.GetComponentInChildren<Text>().text = LinkedLetter.Value;
        }
    }
}
