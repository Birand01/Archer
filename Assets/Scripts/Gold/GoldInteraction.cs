using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldInteraction : InteractionBase
{
    internal float goldGive;
    public static event Action<float> OnIncreaseGoldAmount;
    private void OnEnable()
    {
        
    }
    protected override void OnTriggerEnterAction(Collider collider)
    {
        OnIncreaseGoldAmount?.Invoke(goldGive);
        gameObject.SetActive(false);
    }
}
