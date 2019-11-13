using System;
using System.Collections.Generic;
using GenericEventAndReferences.SOReferences;
using GenericEventAndReferences.SOReferences.BoolReference;
using GenericEventAndReferences.SOReferences.GameObjectReference;
using GenericEventAndReferences.SOReferences.IntReference;
using GenericEventAndReferences.SOReferences.StringListReference;
using GenericEventAndReferences.SOReferences.StringReference;
using GenericEventAndReferences.SOReferences.TextListReference;
using GenericEventAndReferences.SOReferences.TextReference;
using Letters;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Management
{
    public class GameManager : MonoBehaviour
    {
        public LetterBoxesListVariable LettersBoxes;
        public List<Button> Letters = new List<Button>();
        
        public StringListVariable ListOfWords;
        
        public GameObjectVariable LettersButtonPanel;
        
        public GameObjectVariable LetterBoxPrefab;
        public GameObjectVariable WrongLBHandler;
        
        public GameObjectVariable WordZone;
        public GameObjectVariable EndPanel;
        
        public TextVariable WLHandler;
        public TextVariable Win;
        public TextVariable Loose;
        public TextVariable Info;

        public StringVariable WrongLet;
        public StringVariable SelectedWord;
        public StringVariable FirstLetter;
        public StringVariable Empty;
        
        
        public IntVariable maxTries;

        public BoolVariable SetupComplete;
        
        

        private void Awake()
        {
            FirstLetter.Value = "";
            WrongLet.Value = "";
            WLHandler.Value.text = "";
        }

        private void QuitApp()
        {
            Application.Quit();
        }
      
        void SelectWordToFind(GameObject parent)
        {
            LettersBoxes.Value.Clear();
            foreach (var txt in WordZone.Value.GetComponentsInChildren<Text>())
            {
                Destroy(txt.gameObject);
            }
            SelectedWord.Value = ListOfWords.Value[Random.Range(0,ListOfWords.Value.Count-1)];
            FirstLetter.Value = SelectedWord.Value[0].ToString();
            foreach (var let in SelectedWord.Value)
            {
                LettersBoxesComponent LB =
                    Instantiate(LetterBoxPrefab.Value, GameObject.Find(parent.name).transform).GetComponent<LettersBoxesComponent>();
                if (let.ToString() != Empty.Value)
                    LB.LinkedLetter = GameObject.Find(let.ToString()).GetComponent<LettersButtonsComponent>()
                        .LinkedLetter;
                else LB.LinkedLetter = Empty;
                LettersBoxes.Value.Add(LB);
                if (let.ToString() == FirstLetter.Value) LB.DrawLet(FirstLetter);
                if (let == ' ') LB.DrawLet(Empty) ;
                Debug.Log(let);
            }
            SetupComplete.Value = true;
        }
        void SetupButtons()
        {
            Letters.Clear();
            foreach (var btn in LettersButtonPanel.Value.GetComponentsInChildren<Button>())
            {
                Letters.Add(btn);
            }
        }
        public void SetupGame(GameObjectVariable parent)
        {
            FirstLetter.Value = "";
            WrongLet.Value = "";
            WLHandler.Value.text = "";
            SetupButtons();
            SelectWordToFind(parent.Value);
            WLHandler.Value.text = "";
        }
        public void CheckVictory()
        {
            string currentAdv = "";
            foreach (var LB in LettersBoxes.Value)
            {
                currentAdv += LB.GetComponentInChildren<Text>().text;
                Debug.Log(currentAdv);
            }
            if (currentAdv == SelectedWord.Value)EndTheGame(0);
        }
        

        public void CheckLoose()
        {
            if (WrongLet.Value.Length >= maxTries.Value)
            {
                EndTheGame(1);
            }
        }

        

        void EndTheGame(int i)
        {
            EndPanel.Value.SetActive(true);
            switch (i)
            {
                case 0 : 
                    Loose.Value.gameObject.SetActive(false);
                    Win.Value.gameObject.SetActive(true);
                    break;
                case 1 :  
                    Win.Value.gameObject.SetActive(false);
                    Loose.Value.gameObject.SetActive(true);
                    break;
            }
            Info.Value.text = "The word was : " + SelectedWord;
        }
    }
}
