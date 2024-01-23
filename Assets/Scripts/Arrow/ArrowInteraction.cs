using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowInteraction : InteractionBase
{
    protected override void OnTriggerEnterAction(Collider collider)
    {
        collider.gameObject.SetActive(false);
    }
}
