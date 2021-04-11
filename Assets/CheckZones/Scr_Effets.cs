using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Effets : MonoBehaviour
{
    public GameObject cible;
    public GameObject selfCible;


    public void PerteMorale(int value)
    {
        Debug.Log("Perte moral : " + value + " � " + cible);
        cible.GetComponentsInChildren<Scr_TakeDamages>()[0].moral -= value;
    }

    public void GainMoral(int value)
    {
        Debug.Log("Gain moral : " + value + " � " + cible);
        cible.GetComponentsInChildren<Scr_TakeDamages>()[0].moral += value;
    } 

    //Self moral
    public void PerteMoraleSelf(int value)
    {
        Debug.Log("Perte moral : " + value + " � " + selfCible);
        selfCible.GetComponentsInChildren<Scr_TakeDamages>()[0].moral -= value;
    }

    public void GainMoralSelf(int value)
    {
        Debug.Log("Gain moral : " + value + " � " + selfCible);
        selfCible.GetComponentsInChildren<Scr_TakeDamages>()[0].moral += value;
    }


    public void Saignement(int dur�e)
    {
        cible.GetComponent<Scr_TakeDamages>().Saignement(dur�e);
    }

    public void Stun()
    {
        Debug.Log(cible.name + " va �tre stun");
        //Mettre de l'al�atoire
        cible.GetComponent<Scr_TakeDamages>().Stun();
    }

    //
    public void Viser(int value)
    {
        //Au tour suivant la cible aura +x en touche
        Debug.Log("Viser");
        cible.GetComponentsInChildren<Scr_Attaque>()[0].positifModifTouche += value;
    }

    public void PerteTouche(int value)
    {
        //Au tour suivant la cible aura -x en touche
        Debug.Log("Moins de chances de toucher");
        cible.GetComponentsInChildren<Scr_Attaque>()[0].negatifModifTouche -= value;
    }

    //
    public void PerteEsquive(int value)
    {
        //Au tour suivant la cible aura -x en esquive
        Debug.Log("Perte de " + value + " d'esquive ");
        cible.GetComponentsInChildren<Scr_TakeDamages>()[0].esquive -= value;
    }

    public void GainEsquive(int value)
    {
        //Au tour suivant la cible aura +x en esquive
        Debug.Log("Gain de " + value + " d'esquive ");
        cible.GetComponentsInChildren<Scr_TakeDamages>()[0].esquive += value;
    }  
    
    //Self Esquive
    public void PerteEsquiveSelf(int value)
    {
        //Au tour suivant la cible aura -x en esquive
        Debug.Log("Perte de " + value + " d'esquive ");
        selfCible.GetComponentsInChildren<Scr_TakeDamages>()[0].esquive -= value;
    }

    public void GainEsquiveSelf(int value)
    {
        //Au tour suivant la cible aura +x en esquive
        Debug.Log("Gain de " + value + " d'esquive ");
        selfCible.GetComponentsInChildren<Scr_TakeDamages>()[0].esquive += value;
    }


    //
    public void ContreAttaque()
    {
        Debug.Log("Peut faire une Contre atttaque");
        //selfCible

    }

    public void DegatsMortel(int percent)
    {
        //Si l'effet r�ussit met � 0 les pv de son adversaire
        Debug.Log(percent + "% de chances de tuer instant la cible ");
    }

    //
    public void GainAbsorbance(int value)
    {
        Debug.Log("Gain de " + value + " d'absorbance ");
        cible.GetComponentsInChildren<Scr_TakeDamages>()[0].absorbance += value;
    }   
    
    public void PerteAbsorbance(int value)
    {
        Debug.Log("Perte de " + value + " d'absorbance ");
        cible.GetComponentsInChildren<Scr_TakeDamages>()[0].absorbance -= value;

    }

    //
    public void DamageZone()
    {
        //Fait en sorte que tout personnage se trouvant dans la pos X prennet des d�g�ts
    }

    //
    public void Heal(int value)
    {
        //Redonne de la vie � la cible
        Debug.Log(cible + " � regagn� " + value);
    }

    public void StopSaignement()
    {
        cible.GetComponentsInChildren<Scr_TakeDamages>()[0].saignement = false;
    }

    public void PerteSelfPV(int value)
    {
        Debug.Log("Perte vie : " + value + " � " + selfCible);
        selfCible.GetComponentsInChildren<Scr_TakeDamages>()[0].pv -= value;
    }



}
