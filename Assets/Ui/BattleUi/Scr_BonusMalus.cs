using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_BonusMalus : MonoBehaviour
{
    [Header("Visuels")]
    public GameObject bonusVisual;
    public GameObject malusVisual;

    [Header("Scripts du perso")]
    public Scr_TakeDamages takeDamages;
    public Scr_Attaque attaque;

    [Header("Texte")]
    public Text[] bonusText;
    public Text[] malusText;


    public void DisplayBonus()
    {
        int esquiveBonus = takeDamages.esquive - takeDamages.esquive;
        int absorbanceBonus = takeDamages.absorbance - takeDamages.absorbance;
        int bonusTouche = attaque.positifModifTouche;

        if (!bonusVisual.activeSelf)
        {
            bonusVisual.SetActive(true);
        }
        else
        {
            bonusVisual.SetActive(false);
        }
        if (esquiveBonus != 0)
        {
            bonusText[0].text = "Esquive: +" + esquiveBonus;
        }
        if (absorbanceBonus != 0)
        {
            bonusText[1].text = "Absorbance: +" + esquiveBonus;
        }
        if (bonusTouche != 0)
        {
            bonusText[2].text = "Touche: +" + esquiveBonus;
        }
       
        for (int i = 0; i < bonusText.Length; i++)
        {
            if (bonusText[i].text == "")
            {
                bonusText[i].transform.parent.gameObject.SetActive(false);
            }
        }


        




    }

    public void DisplayMalus()
    {
        int esquiveMalus = takeDamages.esquive - takeDamages.esquive;
        int absorbanceMalus = takeDamages.absorbance - takeDamages.absorbance;
        int malusTouche = attaque.positifModifTouche;

        if (!bonusVisual.activeSelf)
        {
            malusVisual.SetActive(true);
        }
        else
        {
            malusVisual.SetActive(false);
        }

        if (esquiveMalus != 0)
        {
            bonusText[0].text = "Esquive: " + esquiveMalus;
        }
        if (absorbanceMalus != 0)
        {
            bonusText[1].text = "Absorbance: " + absorbanceMalus;
        }
        if (malusTouche != 0)
        {
            bonusText[2].text = "Touche: " + malusTouche;
        }

        for (int i = 0; i < bonusText.Length; i++)
        {
            if (bonusText[i].text == "")
            {
                bonusText[i].transform.parent.gameObject.SetActive(false);
            }

        }


    }



    public void HidePannel(GameObject go)
    {
        StartCoroutine(Wait(go));
    }


    IEnumerator Wait(GameObject go)
    {

        yield return new WaitForSeconds(0.5f);
        go.SetActive(false);

    }





}
