using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZoneInteraction : InteractionBase
{
   
  

    protected override void OnTriggerStayAction(Collider other)
    {
       
        IDamageable damageable = gameObject.GetComponentInParent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(other.gameObject.GetComponentInChildren<AttackState>().attackValue);
        }
    }
}
