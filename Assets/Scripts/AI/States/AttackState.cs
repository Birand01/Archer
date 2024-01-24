using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    internal float attackValue=0.1f;
    [SerializeField] private DeadState deadState;
    [SerializeField] private IdleState idleState;
    [SerializeField] private WinState winState;
    // public static event Action<GameObject, float> OnTakeDamageFromBoss;

    public override State RunCurrentState()
    {
        agent.isStopped = true;
        agent.transform.LookAt(_player.position);
        agent.speed = 0f;
        EnemyHealth enemyHealth=this.gameObject.GetComponentInParent<EnemyHealth>();
        if (enemyHealth != null && enemyHealth.Health<=0)
        {
            animator?.CrossFadeInFixedTime("Dead", 0.5f);
            return deadState;
        }
        PlayerHealth playerHealth=_player.GetComponentInParent<PlayerHealth>();
        if(playerHealth != null && playerHealth.Health<=0)
        {
     
                animator?.CrossFadeInFixedTime("Win", 0.5f);
                return winState;
     
        }
       
        return this;
    }
}
