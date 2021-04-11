using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Ennemi : MonoBehaviour
{

    private Scr_TakeDamages takeDamages;
    private Scr_TurnManager turnmanager;
    private Scr_EnnemiAi ai;

    public bool turnFinish;

    public static Action noMoralEvent;
    public static Action endTurnEvent;
    
    public static Action<string> ennemiCapaStart;
    public static Action ennemiCapaEnd;

    public GameObject tombe;
    public GameObject apparence;

    public GameObject turnMarker;

    private void Awake()
    {
        turnmanager = FindObjectOfType<Scr_TurnManager>();
        ai = GetComponent<Scr_EnnemiAi>();
        takeDamages = GetComponent<Scr_TakeDamages>();
        turnMarker = transform.Find("EnnemiTurnMarker").gameObject;

    }

    public void CheckMoral()
    {
        int moral = GetComponent<Scr_TakeDamages>().moral;
        if (moral <= 0)
        {
            //Fuit le combat: x% chances de fuir ou fuite forcément?
            Fuite();
            if (noMoralEvent != null) noMoralEvent();
        }
    }

    public void Fuite()
    {
        Debug.Log("--FUITE--");
        //Désactive tout de l'ennemi
    }

    public void Turn()
    {
        //turnmanager.EnemyEndTurn();
        StartCoroutine(IamInAnimation());
        turnMarker.SetActive(true);
    }

    IEnumerator IamInAnimation()
    {
        yield return new WaitForSeconds(1f);
        ai.Attack(0, "Torso");
        if (ennemiCapaStart != null) ennemiCapaStart(ai.actualCapa.name);

        Debug.Log("Ennemi COUROUTINE START");
        yield return new WaitForSeconds(1f);
        Debug.Log("---Ennemi COUROUTINE FINISH");
        if (ennemiCapaEnd != null) ennemiCapaEnd();
        yield return new WaitForSeconds(0.5f);
        turnFinish = true;
        if (endTurnEvent != null)
            endTurnEvent();
        turnMarker.SetActive(false);
    }


    public void WhenDead()
    {
        //Désactiver tous ses scripts, enlever son truc de d'habitude, et mettre la tombe
        apparence.SetActive(false);
        gameObject.SetActive(false);
        tombe.SetActive(true);



    }






}
