using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    public static event Action<ParticleType, Vector3> OnEnemyDeadParticle;
    public override State RunCurrentState()
    {
        OnEnemyDeadParticle?.Invoke(ParticleType.EnemyDead, transform.position);
        agent.isStopped = true;
        agent.speed = 0;
        this.gameObject.SetActive(false);
        return this;
    }

}
