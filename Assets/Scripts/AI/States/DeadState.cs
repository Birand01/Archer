using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    public override State RunCurrentState()
    {
       
        agent.isStopped = true;
        agent.speed = 0;
        this.gameObject.SetActive(false);
        return this;
    }

}
