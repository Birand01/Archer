using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowInteraction : InteractionBase
{
    public static event Action<SoundType, bool> OnArrowHitSound;
  
    protected override void OnTriggerEnterAction(Collider collider)
    {
        this.gameObject.SetActive(false);
        IDamageable damageable=collider.GetComponent<IDamageable>();
        if (damageable != null)
        {
            OnArrowHitSound?.Invoke(SoundType.ArrowHitSound, true);
            damageable.TakeDamage(collider.gameObject.GetComponent<EnemyHealth>().takenDamage);
        }
       
    }
}
