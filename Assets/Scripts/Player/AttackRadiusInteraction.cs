using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRadiusInteraction : InteractionBase
{
    public static event Action<Collider> OnAddEnemyToDamageableList;
    public static event Action<Collider> OnRemoveEnemyFromDamageableList;

    protected override void OnTriggerEnterAction(Collider collider)
    {
        OnAddEnemyToDamageableList?.Invoke(collider);
    }
    protected override void OnTriggerExitAction(Collider other)
    {
        OnRemoveEnemyFromDamageableList?.Invoke(other);
    }
}
