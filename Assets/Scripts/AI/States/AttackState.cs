using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    internal float stickmanDamage;
    [SerializeField] private State deadState, winState;
   // public static event Action<GameObject, float> OnTakeDamageFromBoss;

    public override State RunCurrentState()
    {
        agent.isStopped = true;
        agent.transform.LookAt(_player.position);
        //OnTakeDamageFromBoss?.Invoke(this.gameObject, stickmanDamage);
        //BossHealth bossHealth = _player.GetComponent<BossHealth>();
        //if (bossHealth != null)
        //{
        //    if (bossHealth.Health <= 0)
        //    {
        //        animator.CrossFadeInFixedTime("Victory", 0.5f);
        //        return winState;

        //    }
        //}
        agent.speed = 0f;
        return this;
    }
}
