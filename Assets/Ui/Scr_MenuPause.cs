using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class Scr_MenuPause : MonoBehaviour
{
    public GameObject pauseMenuPannel;
    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            PauseMenu(pauseMenuPannel);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowPannel(GameObject pannel)
    {
        pannel.SetActive(true);
    }

    public void HidePannel(GameObject pannel)
    {
        pannel.SetActive(false);
    }


    public void PauseMenu(GameObject pauseMenuPannel)
    {
        if (!pauseMenuPannel.activeSelf)
        {
            pauseMenuPannel.SetActive(true);
        }
        else
        {
            pauseMenuPannel.SetActive(false);
        }

    }


}
