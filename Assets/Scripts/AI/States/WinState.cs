using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : State
{
    [SerializeField] private GameObject healthbar;
    public override State RunCurrentState()
    {
        healthbar.SetActive(false);
        agent.isStopped = true;
        agent.speed = 0;       
        return this;
    }

  
}
