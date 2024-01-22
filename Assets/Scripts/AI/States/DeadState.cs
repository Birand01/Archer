using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    public override State RunCurrentState()
    {
        Debug.Log("DEAD");
        return this;
    }

}
