using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalHealthButton : ButtonBase
{
    public static event Action<float> OnIncreseTotalHealthEvent;
    public static event Action<SoundType, bool> OnTotalHealButtonSound;
   
    protected override void OnButtonClickEvent()
    {
        OnPurchaseSkillEvent();
        OnIncreseTotalHealthEvent?.Invoke(skillAmount);
        OnTotalHealButtonSound?.Invoke(SoundType.IncreaseTotalHealthSound, true);
    }
}
