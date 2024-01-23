using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZoneInteraction : InteractionBase
{
    [SerializeField] private float takenDamage;
    public static event Action<float> OnTakeDamageFromPlayer;
    protected override void OnTriggerStayAction(Collider other)
    {
        //OnTakeDamageFromPlayer?.Invoke(takenDamage);
        IDamageable damageable = gameObject.GetComponentInParent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(0.1f);
        }
    }
}
