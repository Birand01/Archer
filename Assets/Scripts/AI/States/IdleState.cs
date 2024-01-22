using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private float startTime = 0f;
    [SerializeField] private float maxWaitIdleTime;
    [SerializeField] private ChaseState chaseState;
    public override State RunCurrentState()
    {
        startTime += Time.deltaTime;
        if (startTime >= maxWaitIdleTime)
        {
            animator?.CrossFadeInFixedTime("Chase", 0.5f);
            startTime = 0;
            return chaseState;
        }
        return this;
    }
}
