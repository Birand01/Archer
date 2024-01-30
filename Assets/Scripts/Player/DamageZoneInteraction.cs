using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZoneInteraction : InteractionBase
{
    public static event Action<ParticleType, Vector3> OnPlayerBloodParticle;
    protected override void OnTriggerStayAction(Collider other)
    {
        OnPlayerBloodParticle?.Invoke(ParticleType.PlayerBlood,new Vector3(transform.position.x,1, transform.position.z) );
         IDamageable damageable = gameObject.GetComponentInParent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(other.gameObject.GetComponentInChildren<AttackState>().attackValue);
        }
    }
}
