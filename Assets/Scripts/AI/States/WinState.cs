using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : State
{
    public override State RunCurrentState()
    {
        agent.isStopped = true;
        agent.speed = 0;       
        return this;
    }

  
}
