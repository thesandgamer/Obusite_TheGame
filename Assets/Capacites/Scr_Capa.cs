using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_Capa : MonoBehaviour
{
    private Scr_TakeDamages playerTakesDamages;

    public Scr_CapaDataBase capaDataBase;
    public Scr_Capacite[] capacite;
    public Scr_Capacite[] autoCapacite;
    public Scr_Items_Capa[] itemCapa;


    private void Start()
    {
        if (!gameObject.CompareTag("Ennemi"))
        {
            playerTakesDamages = GetComponent<Scr_TakeDamages>();
            InitUi();


        }   
    }

    void Update()
    {
        if (!gameObject.CompareTag("Ennemi"))
        {
            InitUi();
        }
    }


    void InitUi()
    {


        for (int i = 0; i < capacite.Length; i++)
        {
            for (int j = 0; j < capaDataBase.AttackCapa[capacite[i].intCapa].attackCapa.Length; j++)
            {
                //Debug.Log("Capa: " + capaDataBase.AutoCapa[capacite[i].intCapa].name);

                if (capacite[i].uiCapaText)
                {
                    capacite[i].uiCapaText.text = capaDataBase.AttackCapa[capacite[i].intCapa].name;

                }
                if (capacite[i].uiCapaAltText[j])
                {
                    //   capacite[i].uiCapaAltText[j].text = capaDataBase.AttackCapa[capacite[i].intCapa].attackCapa[j].name;
                    var moralRequire = capaDataBase.AttackCapa[capacite[i].intCapa].attackCapa[j].moralRequire;
                    //Change l'icone
                    capacite[i].uiCapaAltText[j].transform.parent.gameObject.GetComponent<Image>().sprite = capaDataBase.AttackCapa[capacite[i].intCapa].attackCapa[j].icone;

                    capacite[i].uiCapaAltText[j].transform.parent.gameObject.GetComponent<Button>().interactable = CheckMoral(moralRequire);

                }

            }

        }

        for (int i = 0; i < autoCapacite.Length; i++)
        {
            for (int j = 0; j < capaDataBase.AutoCapa[autoCapacite[i].intCapa].autoCapa.Length; j++)
            {
                //Debug.Log("Capa: " + capaDataBase.AutoCapa[capacite[i].intCapa].name);

                if (autoCapacite[i].uiCapaText)
                {
                    autoCapacite[i].uiCapaText.text = capaDataBase.AutoCapa[autoCapacite[i].intCapa].name;

                }
                if (autoCapacite[i].uiCapaAltText[j])
                {
                    autoCapacite[i].uiCapaAltText[j].text = capaDataBase.AutoCapa[autoCapacite[i].intCapa].autoCapa[j].name;
                    //Change l'icone
                    capacite[i].uiCapaAltText[j].transform.parent.gameObject.GetComponent<Image>().sprite = capaDataBase.AttackCapa[capacite[i].intCapa].attackCapa[j].icone;

                }

            }

        }

        for (int i = 0; i < itemCapa.Length; i++)
        {
            if (itemCapa[i].nom == "Auto")
            {
                itemCapa[i].uiCapaText.text = itemCapa[i].number.ToString();
                //Change le sprite
                itemCapa[i].uiCapaText.transform.parent.gameObject.GetComponent<Image>().sprite = capaDataBase.ItemCapa[0].autoCapa[itemCapa[i].intCapa].icone;
            }
            if (itemCapa[i].nom == "Attack")
            {
                itemCapa[i].uiCapaText.text = itemCapa[i].number.ToString();
                //Change le sprite
                itemCapa[i].uiCapaText.transform.parent.gameObject.GetComponent<Image>().sprite = capaDataBase.ItemCapa[0].attackCapa[itemCapa[i].intCapa].icone;
            }

        }



    }

    bool moralGood;

    bool CheckMoral(int moralRequire)
    {

        if (moralRequire <0)
        {
            return true;
        }
        if (moralRequire > 5)
        {
            if (playerTakesDamages.moral >= moralRequire)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (moralRequire <= 5)
        {
            if (playerTakesDamages.moral <= moralRequire)
            {
                return  true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return true;
        }
    }

}






