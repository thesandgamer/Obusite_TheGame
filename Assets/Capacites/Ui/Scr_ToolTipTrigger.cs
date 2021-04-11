using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Scr_ToolTipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public string header ;

    [Multiline()]
    public string content;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Scr_ToolTipSystem.Show(content,header);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Scr_ToolTipSystem.Hide();
    }



}
