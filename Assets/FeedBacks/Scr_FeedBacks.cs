using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scr_FeedBacks : MonoBehaviour
{
    public GameObject feedBackUi;
    public TMP_Text feedbackText;

    private void Start()
    {
        Scr_TakeDamages.esquiveEvent += EsquiveFeedBacks;

        Scr_Attaque.tirReussitEvent += ToucheFeedBacks;
        Scr_Attaque.tirRateEvent += RateFeedBacks;

        Scr_Attaque.actionReussitEvent += ReussiteFeedBacks;
        Scr_Attaque.actionRateEvent += EchecFeedBacks;
        ;
    }



    public void EsquiveFeedBacks()
    {
        feedbackText.text = "ESQUIVE";
        ShowUi();
    }

    public void ToucheFeedBacks()
    {
        feedbackText.text = "TIR REUSSIT";
        ShowUi();
    }
    public void RateFeedBacks()
    {
        feedbackText.text = "TIR MANQUE";
        ShowUi();
    }
    
    public void ReussiteFeedBacks()
    {
        feedbackText.text = "ACTION REUSSIE";
        ShowUi();
    }
    public void EchecFeedBacks()
    {
        feedbackText.text = "ACTION RATE";
        ShowUi();
    }



    public void ShowUi()
    {
        feedBackUi.SetActive(true);
        StartCoroutine(timeToShowFeedBack());
        StartCoroutine(FadeIn());
    }
    public void HideUi()
    {
        feedbackText.text = "";
        feedBackUi.SetActive(false);
       
    }


    public IEnumerator timeToShowFeedBack()
    {
        
        yield return new WaitForSeconds(1f);
       // StartCoroutine(FadeOut());
        HideUi();


    }

    private float fadeSpeed = 1;

    public IEnumerator FadeOut()
    {
        Color textColor = feedbackText.color;
        while (textColor.a >0)
        {
            float fadeAmount = textColor.a - (fadeSpeed * Time.deltaTime);
            textColor = new Color(textColor.r, textColor.g, textColor.b, fadeAmount);

            yield return null;

        }
        //HideUi();


    }

    public IEnumerator FadeIn()
    {
        Color textColor = feedbackText.color;
        while (textColor.a > 0)
        {
           float fadeAmount = textColor.a + (fadeSpeed * Time.deltaTime);
           textColor.a += (fadeSpeed * Time.deltaTime);

            yield return null;
        }


    }






    private void OnDisable()
    {
        Scr_TakeDamages.esquiveEvent -= EsquiveFeedBacks;

        Scr_Attaque.tirReussitEvent -= ToucheFeedBacks;
        Scr_Attaque.tirRateEvent -= RateFeedBacks;
    }








}
