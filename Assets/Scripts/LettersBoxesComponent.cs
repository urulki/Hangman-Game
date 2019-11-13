using System;
using GenericEventAndReferences.SOEvents.VoidEvents;
using GenericEventAndReferences.SOReferences.StringReference;
using UnityEngine;
using UnityEngine.UI;

public class LettersBoxesComponent : MonoBehaviour
{
    public StringVariable LinkedLetter;
    
    public void DrawLet(StringVariable check)
    {
        if(LinkedLetter.Value == check.Value) GetComponentInChildren<Text>().text = LinkedLetter.Value;
    }
}