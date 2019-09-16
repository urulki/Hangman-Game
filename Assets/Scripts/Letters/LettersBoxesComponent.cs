using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LettersBoxesComponent : MonoBehaviour
{
    public char LinkedLetter;

    public void DrawLet()
    {
        GetComponentInChildren<Text>().text = LinkedLetter.ToString();
    }
}