using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AttackRangeButton : ButtonBase
{
    [Inject] VirtualCamera _camera;
    public static event Action<float> OnIncreaseAttackRangeEvent;
    protected override void OnButtonClickEvent()
    {
        OnPurchaseSkillEvent();
        OnIncreaseAttackRangeEvent?.Invoke(skillAmount);
    }
    

    protected override void ButtonInteractability()
    {
        base.ButtonInteractability();
        if(_camera._transposer.m_FollowOffset.y>=30)
        {
            IsButtonInteractable(false);
        }
    }

}
