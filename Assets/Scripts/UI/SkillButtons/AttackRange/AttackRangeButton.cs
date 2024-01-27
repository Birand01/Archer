using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeButton : ButtonBase
{
    public static event Action<float> OnIncreaseAttackRangeEvent;
    protected override void OnButtonClickEvent()
    {
        OnIncreaseAttackRangeEvent?.Invoke(skillAmount);
    }
}
