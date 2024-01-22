using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    [SerializeField] private AttackState attackState;
    public override State RunCurrentState()
    {
        agent.transform.LookAt(_player.position);
        agent.SetDestination(_player.transform.position);

        if (_player != null && Vector3.Distance(transform.position, _player.transform.position) <= agent.stoppingDistance)
        {

            animator?.CrossFadeInFixedTime("Attack", 0.5f);
            return attackState;
        }
        else
        {
            return this;
        }

    }

}
