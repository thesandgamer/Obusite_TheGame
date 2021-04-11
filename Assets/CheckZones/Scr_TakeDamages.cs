using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Scr_TakeDamages : MonoBehaviour
{

    [Header("Base")]
    public int basePv = 10;
    public int baseEsquive = 5;
    public int baseAbsorbance = 0;
    public int moralMax = 20;

    [HideInInspector] public int esquive;
    [HideInInspector] public int absorbance;

    [Header("Actual")]
    public int moral = 10;
    public int pv;

    public bool saignement = false;
    [HideInInspector] public int dureeSaignement;
    public bool stun = false;
    public bool dead = false;

    private Scr_Attaque attaqueManager;
    private Scr_TurnManager turnManger;

    public delegate void DeathDelagate();
    public static event DeathDelagate deathEvent;
    public static Action playerDeath;
    public static Action backInCombat;
    public static Action esquiveEvent;

    [Header("Render")]
    public GameObject stunRenderer;
    public GameObject saignementRenderer;


    public void Start()
    {
        pv = basePv;
        esquive = baseEsquive;
        absorbance = baseAbsorbance;
        attaqueManager = GetComponent<Scr_Attaque>();
        Scr_TakeDamages.deathEvent += PerteMoral;
    }

    public void TakeDamages(int damages, string part)
    {
        int rd = UnityEngine.Random.Range(1, 100);
        if (rd < esquive)
        {
            if (esquiveEvent != null) esquiveEvent();
            Debug.Log("ESQUIVE");
        }
        else
        {
            if (pv > 0)
            {
                int damageTaken = damages;
                switch (part)
                {
                    case "Head":
                        pv -= damages - absorbance;
                        damageTaken = damages - absorbance;
                        break;
                    case "Torso":
                        pv -= damages - absorbance + 2;
                        damageTaken = damages - absorbance + 2;
                        break;

                }

                Debug.Log(gameObject.name + " lui reste : " + pv + " PV");
                if (damageTaken > pv)
                {
                    Dead();
                }

            }
        }

    }

    public void Dead()
    {
        FindObjectOfType<AudioManager>().Play("Dead");
        dead = true;
        if (CompareTag("Player"))
        {
            if (playerDeath != null)
                playerDeath();
        }
        if (CompareTag("Ennemi"))
        {
            if (deathEvent != null)
                deathEvent();
            GetComponent<Scr_Ennemi>().WhenDead();
        }


    }


    public void Turn()
    {

        if (saignement)
        {
            if (dureeSaignement > 0)
            {
                dureeSaignement--;
                pv -= 1;
            }
            else
            {
                saignement = false;
                saignementRenderer.SetActive(false);
            }

        }
        ResetValue();


    }

    //
    public void Saignement(int durée)
    {
        saignement = true;
        saignementRenderer.SetActive(true);
        dureeSaignement = durée;
    }


    public void Stun()
    {
        stun = true;
        stunRenderer.SetActive(true);
        if (deathEvent != null)
            deathEvent();
    }

    public void ResetValue()
    {
        esquive = baseEsquive;
        absorbance = baseAbsorbance;
        attaqueManager.positifModifTouche = 0;
        attaqueManager.negatifModifTouche = 0;

    }

    public void UnStun()
    {

        if (stun)
        {
            if (CompareTag("Ennemi"))
            {
                if (backInCombat != null)
                    backInCombat();
            }
            stun = false;
            stunRenderer.SetActive(false);

        }


    }


    void PerteMoral()
    {
        moral -= 2;
    }





}
