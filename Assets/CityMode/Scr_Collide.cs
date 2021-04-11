using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Collide : MonoBehaviour
{
    public GameObject collide;

    public GameObject dialogueUi;

    public Action collideForCombat;

    public GameObject turnManager;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (collide.GetComponent<Scr_TurnManager>())
            {
                //turnManager.SetActive(true);
                dialogueUi.SetActive(true);
                other.transform.GetChild(0).gameObject.SetActive(false);
                dialogueUi.GetComponent<Scr_UiManager>().collide = collide; 
            }

        }

    }

}
