using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class Scr_Attaque : MonoBehaviour
{
    public Scr_MovePositions posScript;
    int actualPosition;
    private Scr_Effets effets;

    public int positifModifTouche;
    public int negatifModifTouche;

    public static Action tirReussitEvent;
    public static Action tirRateEvent;

    public static Action actionReussitEvent;
    public static Action actionRateEvent;

    private void Start()
    {
        posScript = GetComponent<Scr_MovePositions>();
        effets = FindObjectOfType<Scr_Effets>();
    }

    public void CalculateIfMakeDamages(GameObject opponent, Scr_AttackCapa capacite, Transform selfPos, string part)
    {
        /*
        if (opponent.GetComponent<Scr_Ennemi>())
        {
            var ennemi = opponent.GetComponent<Scr_Ennemi>();
            int esquive = ennemi.esquive;
        }
        if (opponent.GetComponent<Scr_Player>())
        {
           var ennemi = opponent.GetComponent<Scr_Player>();
           int esquive = ennemi.esquive;
        }
        */

        if (opponent.GetComponent<Scr_TakeDamages>())
        {
            var ennemi = opponent.GetComponent<Scr_TakeDamages>();
            int esquive = ennemi.esquive;
        }

        int toReach = capacite.touche;
        int value = UnityEngine.Random.Range(1, 100);
        //Debug.Log("Position : " + selfPos);

        

        //Debug.Log("Portée taille: " + capacite.portee.Length);


        for (int i = 0; i <4; i++)
        {
            if (selfPos == posScript.pos[i])
            {
                actualPosition = i;
            }
        }

        //Modifie la Touche en fonction de la position si elle à un modificateur
        value -= capacite.modifPortee[actualPosition];

        //Modifie la touche en fonction de la partie
        Debug.Log(part);
        switch (part)
        {
            case "Head":
                Debug.Log("Tête touchée");
                value -= 5;
                break;
            case "Torso":
                Debug.Log("Torce touchée");
                break;

        }

        value += positifModifTouche;
        value += negatifModifTouche;

        //Mettre en place l'equive de la cible

        //Modifie la chance de saignement/... en fonction de la partie
        if (value <= toReach)
        {   
            opponent.GetComponent<Scr_TakeDamages>().TakeDamages(UnityEngine.Random.Range(capacite.degats[0], capacite.degats[1]), part);
            effets.cible = opponent;
            effets.selfCible = gameObject;
            capacite.effet.Invoke();
            PlaySound(capacite);
            if (tirReussitEvent != null) tirReussitEvent();
        }
        else
        {
            Debug.Log("Tir raté");
            if (tirRateEvent != null) tirRateEvent();
        }
        
    }

    public void CalculateIfTouch(GameObject cible, Scr_AutoCapa capacite)
    {
        int toReach = capacite.touche;
        int value = UnityEngine.Random.Range(1, 100);

        if (value <= toReach)
        {
            effets.cible = cible;
            effets.selfCible = gameObject;
            capacite.effet.Invoke();
            if (tirReussitEvent != null) actionReussitEvent();
        }
        else
        {
            if (actionRateEvent != null) actionRateEvent();
        }

    }

    public void PlaySound(Scr_AttackCapa capacite)
    {
        switch (capacite.name)
        {
            case "Tir normal":
                FindObjectOfType<AudioManager>().Play("Tir");
                break;
            case "Points vitaux":
                FindObjectOfType<AudioManager>().Play("Tir");
                break;
            case "Tir sommation":
                FindObjectOfType<AudioManager>().Play("Tir");
                break;

            
            case "Poignardage":
                FindObjectOfType<AudioManager>().Play("Couteau");
                break;
            case "Evicération":
                FindObjectOfType<AudioManager>().Play("Couteau");
                break;
            case "Efleurement":
                FindObjectOfType<AudioManager>().Play("Couteau");
                break;


            case "Coup Pelle":
                FindObjectOfType<AudioManager>().Play("CoupPelle");
                break;
            
            case "Coup dague":
                FindObjectOfType<AudioManager>().Play("Couteau");
                break;
            
            case "Tir pistolet":
                FindObjectOfType<AudioManager>().Play("Tir");
                break;



        }
    }




}
