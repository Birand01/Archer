using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    internal float stickmanDamage;
    [SerializeField] private DeadState deadState;
    [SerializeField] private IdleState idleState;
   // public static event Action<GameObject, float> OnTakeDamageFromBoss;

    public override State RunCurrentState()
    {
        agent.isStopped = true;
        agent.transform.LookAt(_player.position);
        EnemyHealth enemyHealth=this.gameObject.GetComponentInParent<EnemyHealth>();
        if (enemyHealth != null && enemyHealth.Health<=0)
        {
            animator?.CrossFadeInFixedTime("Dead", 0.5f);
            return deadState;
        }
        agent.speed = 0f;
        return this;
    }
}
