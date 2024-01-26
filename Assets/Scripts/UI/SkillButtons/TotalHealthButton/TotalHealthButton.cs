using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalHealthButton : ButtonBase
{
    public static event Action<float> OnIncreseTotalHealthEvent;

    protected override void OnEnable()
    {
        base.OnEnable();
        PlayerHealth.OnPurchaseBoostTotalHealthEvent += OnPurchaseSkillEvent;
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        PlayerHealth.OnPurchaseBoostTotalHealthEvent -= OnPurchaseSkillEvent;
    }
    protected override void OnButtonClickEvent()
    {
        OnIncreseTotalHealthEvent?.Invoke(skillAmount);
    }
}
