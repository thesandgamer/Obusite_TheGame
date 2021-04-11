using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_ToolTipSystem : MonoBehaviour
{
    private static Scr_ToolTipSystem current;
    public Scr_ToolTip toolTip;

    public void Awake()
    {
        current = this;
    }


    public static void Show(string content, string header = "")
    {
        current.toolTip.SetText(content, header);
        current.toolTip.gameObject.SetActive(true);
    }
    
    public static void Hide()
    {
        current.toolTip.gameObject.SetActive(false);
    }



}
