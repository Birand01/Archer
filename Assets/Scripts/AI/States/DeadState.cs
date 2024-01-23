using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    public override State RunCurrentState()
    {
        this.gameObject.SetActive(false);
        return this;
    }

}
