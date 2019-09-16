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
        
        public Dictionary<char,Button> Letters = new Dictionary<char, Button>();
        public List<string> WordsToFind = new List<string>();
        public List<Text> LettersBoxes = new List<Text>();

        public GameObject LetterBoxPrefab;
        public Button StartButton;
        public GameObject WordZone;
        public string SelectedWord;
        public string CurrentProgress;
        public GameObject LettersButtonPanel;
        public GameObject LetterButtonPrefab;
        
        
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
                Text text = Instantiate(LetterBoxPrefab, WordZone.transform).GetComponent<Text>();
                LettersBoxes.Add(text);
                if (let == firstLet) text.text = let.ToString();
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
            CurrentProgress += SelectedWord[0].ToString();
        }

        void CheckLetter(char lKey)
        {
            foreach (var let in SelectedWord)
            {
                foreach (var letBox in LettersBoxes)
                {
                    if (lKey == let)
                    {
                        let.text = lKey.ToString();
                        if(Letters[lKey].gameObject.activeSelf)Letters[lKey].gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
