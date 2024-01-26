using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthButton : ButtonBase
{
   
    public static event Action<float> OnGainHealthEvent;

    protected override void OnEnable()
    {
        PlayerHealth.OnPurchaseBoostHealthEvent += OnPurchaseSkillEvent;
        base.OnEnable();
    }
    protected override void OnDisable()
    {
        PlayerHealth.OnPurchaseBoostHealthEvent -= OnPurchaseSkillEvent;
        base.OnDisable();
    }
    protected override void OnButtonClickEvent()
    {
        OnGainHealthEvent?.Invoke(skillAmount);
    }


   

}
