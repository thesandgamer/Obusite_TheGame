using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Scr_UiManager : MonoBehaviour
{

    public static Action combatStartEvent;

    public GameObject collide;

    public GameObject UiDialogue;

    public GameObject player;


    public void SetupBattle()
    {
        UiDialogue.SetActive(false);

        collide.GetComponent<Scr_TurnManager>().SetupBattle();
        if (combatStartEvent != null)
            combatStartEvent();

    }

    public void Partir()
    {
        UiDialogue.SetActive(false);
        player.transform.GetChild(0).gameObject.SetActive(true);
    }



}
