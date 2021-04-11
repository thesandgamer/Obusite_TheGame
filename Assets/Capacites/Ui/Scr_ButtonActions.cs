using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Scr_ButtonActions : MonoBehaviour
{

    public GameObject[] attackCapaPannel;
    public GameObject[] inventairePannel;
    public GameObject[] autoCapaPannel;

    public GameObject[] CategoriePannel;

    public void ShowHideCapaPannel(GameObject pannel)
    {

        if (!pannel.activeSelf)
        {
            pannel.SetActive(true);
        }
        else if (pannel.activeSelf)
        {
            pannel.SetActive(false);
        }
        

    }


    public void HideAllPannelsExeptThis(GameObject pannel)
    {
        if (pannel == inventairePannel[0])
        {
            CleanAttackUi();
            autoCapaPannel[0].SetActive(false);
            CategoriePannel[0].SetActive(false);
        }
        else if(pannel == autoCapaPannel[0])
        {
            CleanAttackUi();
            inventairePannel[0].SetActive(false);
            CategoriePannel[0].SetActive(false);
        }
        else
        {
            inventairePannel[0].SetActive(false);
            autoCapaPannel[0].SetActive(false);      
            for (int i = 0; i < attackCapaPannel.Length; i++)
            {
                if(attackCapaPannel[i] != pannel)
                {
                    attackCapaPannel[i].SetActive(false);
                }
            }
        }

    } 

    
    public void HideAllCategoriePannelsExeptThis(GameObject pannel)
    {

    }


    void CleanAttackUi()
    {
        for (int i = 0; i<attackCapaPannel.Length;i++)
        {
            attackCapaPannel[i].SetActive(false);

        }
    }


    

    public void HidePannel(GameObject pannel)
    {
        pannel.SetActive(false);
    }
    
    public void ShowPannel(GameObject pannel)
    {
        pannel.SetActive(true);
    }



}
