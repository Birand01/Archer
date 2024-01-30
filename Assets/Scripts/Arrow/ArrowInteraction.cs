using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ArrowInteraction : InteractionBase
{
   
    public static event Action<SoundType, bool> OnArrowHitSound;
    public static event Action<ParticleType, Vector3> OnArrowHitParticle;
   
    protected override void OnTriggerEnterAction(Collider collider)
    {
         gameObject.SetActive(false);
        IDamageable damageable=collider.GetComponent<IDamageable>();
        if (damageable != null)
        {
            OnArrowHitParticle.Invoke(ParticleType.ArrowHit, this.transform.position);
            OnArrowHitSound?.Invoke(SoundType.ArrowHitSound, true);
            damageable.TakeDamage(collider.gameObject.GetComponent<EnemyHealth>().takenDamage);
           
        }
       
    }
}
