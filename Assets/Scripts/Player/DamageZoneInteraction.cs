using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZoneInteraction : InteractionBase
{
   
    public static event Action<float> OnTakeDamageFromPlayer;

    protected override void OnTriggerStayAction(Collider other)
    {
        // OnTakeDamageFromPlayer?.Invoke(other.gameObject.GetComponentInChildren<AttackState>().attackValue);
        IDamageable damageable = gameObject.GetComponentInParent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(other.gameObject.GetComponentInChildren<AttackState>().attackValue);
        }
    }
}
