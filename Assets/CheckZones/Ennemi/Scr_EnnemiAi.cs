using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_EnnemiAi : MonoBehaviour
{
    private Scr_MovePositions posManager;
    private Scr_Capa capaManager;
    private Scr_CapaDataBase dataBase;
    private Scr_Attaque attaqueManager;

    public GameObject player;

    [HideInInspector] public Scr_AttackCapa actualCapa;

    private void Awake()
    {
        posManager = GetComponent<Scr_MovePositions>();
        capaManager = GetComponent<Scr_Capa>();
        attaqueManager = GetComponent<Scr_Attaque>();
        dataBase = FindObjectOfType<Scr_CapaDataBase>();
    }


    public void Move()
    {

        //D�tecter o� on est 

        //Prendre un num�ro au pif
        int i = Random.Range(0, 4);
        //Prendre un autre num�ro si le num�ro est le m�me que l� o� on est
        i = Random.Range(0, 4);
        //D�placer � la position du num�ro
        posManager.MoveToPosition(posManager.pos[i]);

        if (posManager.actualPosition != posManager.pos[i])
        {
            
        }





    }

    public void ChooseCapa()
    {

    }


    public void Attack(int attaque, string part)
    {
        int actualCapaInt = capaManager.capacite[attaque].intCapa;

        actualCapa = dataBase.AttackCapa[actualCapaInt].attackCapa[1];

        attaqueManager.CalculateIfMakeDamages(player, actualCapa, posManager.actualPosition,part) ;

    }

}
