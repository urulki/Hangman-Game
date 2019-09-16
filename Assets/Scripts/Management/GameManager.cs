using System;
using System.Collections.Generic;
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
        public Dictionary<char,Button> Letters = new Dictionary<char, Button>();
        
        public ListOfWords ListOfWords;
        
        public GameObject LettersButtonPanel;
        public GameObject LetterButtonPrefab;
        public GameObject LetterBoxPrefab;
        public GameObject WrongLBHandler;
        public GameObject WrongLBPrefab;
        public GameObject WordZone;
        public GameObject EndPanel;
        
        public Button StartButton;
        public Button ReplayButton;
        public Button QuitButton;
        
        public Text WLHandler;
        public Text Win;
        public Text Loose;
        public Text Info;

        public String WrongLet = "";
        public string SelectedWord;
       
        private int maxTries = 10;
        
        // Start is called before the first frame update
        void Awake()
        {
            StartButton.onClick.AddListener(SetupGame);
            ReplayButton.onClick.AddListener(ReloadGame);
            QuitButton.onClick.AddListener(QuitApp);
        }

        private void QuitApp()
        {
            Application.Quit();
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
            LettersBoxes.Clear();
            foreach (var txt in WordZone.GetComponentsInChildren<Text>())
            {
                Destroy(txt.gameObject);
            }
            SelectedWord = ListOfWords.WordsToFind[Random.Range(0,ListOfWords.WordsToFind.Count-1)];
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
            UnactiveLetButton(firstLet);
        }

        

        void SetupButtons()
        {
            Letters.Clear();
            foreach (var btn in LettersButtonPanel.GetComponentsInChildren<Button>())
            {
                Destroy(btn.gameObject);
            }
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
            if (currentAdv == SelectedWord)EndTheGame(0);
        }

        void DrawWL(char c)
        {
            if (!WrongLet.Contains(c.ToString()) && !SelectedWord.Contains(c.ToString()))
            {
                WrongLet += c.ToString();
                WLHandler.text = WrongLet;
                CheckLoose();
                UnactiveLetButton(c);
            }
        }

        void CheckLoose()
        {
            if (WrongLet.Length >= maxTries)
            {
                EndTheGame(1);
            }
        }

        void UnactiveLetButton(char c)
        {
            if(Letters[c].gameObject.activeSelf)Letters[c].gameObject.SetActive(false);
        }

        void EndTheGame(int i)
        {
            EndPanel.SetActive(true);
            switch (i)
            {
                case 0 : 
                    Loose.gameObject.SetActive(false);
                    Win.gameObject.SetActive(true);
                    break;
                case 1 :  
                    Win.gameObject.SetActive(false);
                    Loose.gameObject.SetActive(true);
                    break;
            }
            Info.text = "The word was : " + SelectedWord;
        }

        void ReloadGame()
        {
            EndPanel.SetActive(false);
            SetupGame();
        }
    }
}
