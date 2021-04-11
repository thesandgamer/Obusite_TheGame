using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
  public GameObject A1;
  public void ToggleVisibilty()
{
    Renderer rend = A1.GetComponent<Renderer>();

    if(rend.enabled)

    rend.enabled = false;

    else

    rend.enabled = true;

    Debug.Log("Message");
}
}
