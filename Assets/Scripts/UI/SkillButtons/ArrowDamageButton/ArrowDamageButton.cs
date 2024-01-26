using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDamageButton : ButtonBase
{
    public static event Action<float> OnIncreaseArrowDamageEvent;
    protected override void OnEnable()
    {
        base.OnEnable();
        EnemyHealth.OnPurchaseBoostArrowDamageEvent += OnPurchaseSkillEvent;
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        EnemyHealth.OnPurchaseBoostArrowDamageEvent -= OnPurchaseSkillEvent;

    }
    protected override void OnButtonClickEvent()
    {
        OnIncreaseArrowDamageEvent?.Invoke(skillAmount);

    }

   
}
