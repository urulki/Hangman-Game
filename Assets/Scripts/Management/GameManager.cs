using System;
using System.Collections.Generic;
using Letters;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Management
{
    public class GameManager : MonoBehaviour
    {
        public List<LettersBoxesComponent> LettersBoxes = new List<LettersBoxesComponent>();
        public Dictionary<char,Button> Letters = new Dictionary<char, Button>();
        public List<string> WordsToFind = new List<string>();
        public List<Text> WrongLet = new List<Text>();
        
        public GameObject LettersButtonPanel;
        public GameObject LetterButtonPrefab;
        public GameObject LetterBoxPrefab;
        public GameObject WrongLBHandler;
        public GameObject WrongLBPrefab;
        public GameObject WordZone;
        
        public Button StartButton;
        
        public string SelectedWord;

        private int maxTries = 10;
        
        // Start is called before the first frame update
        void Awake()
        {
            StartButton.onClick.AddListener(SetupGame);
            WordsToFind.Add("AMELEA");
        }

        // Update is called once per frame


        private void OnGUI()
        {
            EventSystem e = EventSystem.current;
            if (e.currentSelectedGameObject.name.Length <2)
            {
                char key = Char.Parse(e.currentSelectedGameObject.name);
                Debug.Log(key);
                CheckLetter(key);
            }
        }
    

        void SelectWordToFind()
        {
            SelectedWord = WordsToFind[Random.Range(0,WordsToFind.Count-1)];
            char firstLet = SelectedWord[0];
            foreach (var let in SelectedWord)
            {
                LettersBoxesComponent LB = 
                    Instantiate(LetterBoxPrefab, WordZone.transform).GetComponent<LettersBoxesComponent>();
                LB.LinkedLetter = let;
                LettersBoxes.Add(LB);
                if (let == firstLet) LB.DrawLet();
                if (let == ' ') LB.DrawLet();
                Debug.Log(let);
            }
            Letters[SelectedWord[0]].gameObject.SetActive(false);
        }

        

        void SetupButtons()
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                GameObject go = Instantiate(LetterButtonPrefab, LettersButtonPanel.transform);
                go.name = c.ToString();
                go.SetActive(true);
                Letters.Add(c,go.GetComponent<Button>());
            }
        }

        void SetupGame()
        {
            SetupButtons();
            SelectWordToFind();
        }

        void CheckLetter(char lKey)
        {
            foreach (var letBox in LettersBoxes)
            {
                if (lKey == letBox.LinkedLetter)
                {
                    letBox.DrawLet();
                    if(Letters[lKey].gameObject.activeSelf)Letters[lKey].gameObject.SetActive(false);
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
            if (currentAdv == SelectedWord)Debug.Log("Victiore");
        }

        void DrawWL(char c)
        {
            if (WrongLet.Find(c))
            
            {
                Text text = Instantiate(WrongLBPrefab, WrongLBHandler.transform).GetComponent<Text>();
                text.text = c.ToString();
                text.name = text.text;
                WrongLet.Add(text);
            }
        }

        void CheckLoose()
        {
            if (WrongLet.Count >= maxTries)
            {
                Debug.Log("yousk");
            }
        }
    }
}
