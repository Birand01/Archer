using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class ChaseState : State
{
    [SerializeField] private AttackState attackState;
    [SerializeField] private DeadState deadState;
    public override State RunCurrentState()
    {
        agent.transform.LookAt(_player.position);
        agent.SetDestination(_player.transform.position);

        if (_player != null && Vector3.Distance(transform.position, _player.transform.position) <= agent.stoppingDistance)
        {

            animator?.CrossFadeInFixedTime("Attack", 0.5f);
            return attackState;
        }
        EnemyHealth enemyHealth = this.gameObject.GetComponentInParent<EnemyHealth>();
        if (enemyHealth != null && enemyHealth.Health <= 0)
        {
            animator?.CrossFadeInFixedTime("Dead", 0.5f);
            return deadState;
        }
        else
        {
            return this;
        }

    }

}
