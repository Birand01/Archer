using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowInteraction : InteractionBase
{
    [SerializeField] private float arrowDamage;
    protected override void OnTriggerEnterAction(Collider collider)
    {
        this.gameObject.SetActive(false);
        IDamageable damageable=collider.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(collider.gameObject.GetComponent<EnemyHealth>().takenDamage);
        }
       
    }
}
