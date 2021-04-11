using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_UiBar : MonoBehaviour
{
    public Image pvFill;
    public Image moralFill;

    public Scr_TakeDamages personnage;

    // Start is called before the first frame update
    void Start()
    {
        pvFill.fillAmount = 1;
        moralFill.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        pvFill.fillAmount = (float)personnage.pv / personnage.basePv;
        moralFill.fillAmount = (float)personnage.moral / personnage.moralMax;
    }


}
