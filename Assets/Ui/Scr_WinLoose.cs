using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Scr_WinLoose : MonoBehaviour
{
    public Text endText;
    private void Start()
    {
        Scr_TakeDamages.playerDeath += LooseChangeText;
        Scr_TurnManager.winEvent += WinChangeText;

    }

    public void WinChangeText()
    {
        endText.text = "Combat Win";
        StartCoroutine(Reset());
    }
    
    public void LooseChangeText()
    {
        endText.text = "Combat Loose";
        StartCoroutine(Reset());
    }
    IEnumerator Reset()
    {
        yield return new WaitForSeconds(5f);
        endText.text = "";
    }

    private void OnDisable()
    {
        Scr_TakeDamages.playerDeath -= LooseChangeText;
        Scr_TurnManager.winEvent -= WinChangeText;

    }




}
