using System;
using System.Collections.Generic;
using GenericEventAndReferences.SOEvents.VoidEvents;
using GenericEventAndReferences.SOReferences.GameObjectReference;
using GenericEventAndReferences.SOReferences.IntReference;
using GenericEventAndReferences.SOReferences.StringReference;
using GenericEventAndReferences.SOReferences.TextReference;
using Letters;
using SO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Management
{
    public class GameManager : MonoBehaviour
    {
        public List<LettersBoxesComponent> LettersBoxes = new List<LettersBoxesComponent>();
        public List<Button> Letters = new List<Button>();
        
        public ListOfWords ListOfWords;
        
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
       
        public IntVariable maxTries;

        private void Awake()
        {
            
        }


        private void QuitApp()
        {
            Application.Quit();
        }

        
      
        void SelectWordToFind(GameObject parent)
        {
            LettersBoxes.Clear();
            foreach (var txt in WordZone.Value.GetComponentsInChildren<Text>())
            {
                Destroy(txt.gameObject);
            }
            SelectedWord.Value = ListOfWords.WordsToFind[Random.Range(0,ListOfWords.WordsToFind.Count-1)];
            string firstLet = SelectedWord.Value[0].ToString();
            foreach (var let in SelectedWord.Value)
            {
                LettersBoxesComponent LB = 
                    Instantiate(LetterBoxPrefab.Value, parent.transform).GetComponent<LettersBoxesComponent>();
                LB.LinkedLetter = let;
                LettersBoxes.Add(LB);
                if (let.ToString() == firstLet) LB.DrawLet();
                if (let == ' ') LB.DrawLet();
                Debug.Log(let);
            }
            UnactiveLetButton(GameObject.Find(firstLet).GetComponent<Button>());
        }

        

        void SetupButtons()
        {
            Letters.Clear();
            foreach (var btn in LettersButtonPanel.Value.GetComponentsInChildren<Button>())
            {
                Letters.Add(btn);
            }
        }

        public void SetupGame(GameObject parent)
        {
            SetupButtons();
            SelectWordToFind(parent);
            WLHandler.Value.text = "";
        }

        public void CheckLetter(Button lKey)
        {
            foreach (var letBox in LettersBoxes)
            {
                if (lKey.GetComponentInChildren<Text>().text == letBox.LinkedLetter.ToString())
                {
                    letBox.DrawLet();
                    UnactiveLetButton(lKey);
                }
                else DrawWL(lKey);
            }
            CheckVictory();
        }

        void CheckVictory()
        {
            string currentAdv = "";
            foreach (var LB in LettersBoxes)
            {
                currentAdv += LB.GetComponentInChildren<Text>().text;
            }
            if (currentAdv == SelectedWord.Value)EndTheGame(0);
        }

        void DrawWL(Button b)
        {
            if (!WrongLet.Value.Contains(b.GetComponent<LettersButtonsComponent>().LinkedLetter.Value) && 
                !SelectedWord.Value.Contains(b.GetComponent<LettersButtonsComponent>().LinkedLetter.Value))
            {
                WrongLet.Value += b.GetComponent<LettersButtonsComponent>().LinkedLetter.Value;
                WLHandler.Value.text = WrongLet.Value;
                CheckLoose();
                UnactiveLetButton(b);
            }
        }

        void CheckLoose()
        {
            if (WrongLet.Value.Length >= maxTries.Value)
            {
                EndTheGame(1);
            }
        }

        void UnactiveLetButton(Button LetterBut)
        {
            if(LetterBut.interactable)LetterBut.interactable = false;
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
