using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalHealthButton : ButtonBase
{
    public static event Action<float> OnIncreseTotalHealthEvent;

  
    protected override void OnButtonClickEvent()
    {
        OnPurchaseSkillEvent();
        OnIncreseTotalHealthEvent?.Invoke(skillAmount);
    }
}
