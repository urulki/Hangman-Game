using System;
using Management;
using UnityEngine;
using UnityEngine.UI;

namespace Letters
{
    public class LettersButtonsComponent : MonoBehaviour
    {
        private Button currentBtn;
        
        // Start is called before the first frame update
        void Awake()
        {
            currentBtn = GetComponent<Button>();
        }

        private void OnEnable()
        {
            currentBtn.GetComponentInChildren<Text>().text = currentBtn.name;
        }
    }
}
