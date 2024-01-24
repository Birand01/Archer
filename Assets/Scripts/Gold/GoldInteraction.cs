using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldInteraction : InteractionBase
{
    public static event Action<float> OnIncreaseGoldAmount;
    protected override void OnTriggerEnterAction(Collider collider)
    {
        OnIncreaseGoldAmount?.Invoke(0.2f);
        gameObject.SetActive(false);
    }
}
