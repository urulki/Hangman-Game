using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LettersButtonsComponent : MonoBehaviour
{
    private Button currentBtn;
    
    // Start is called before the first frame update
    void Awake()
    {
        currentBtn = GetComponent<Button>();
    }

    private void Start()
    {
        currentBtn.GetComponentInChildren<Text>().text = currentBtn.name;
    }

    public void CheckLetter()
    {
        
    }
}
