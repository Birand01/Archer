using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRadius : MonoBehaviour
{
    [SerializeField] private List<IDamageable> damageables;
    [SerializeField] internal float minDistanceToAttack;
    internal float attackDelay;
    private Coroutine attackCoroutine;

    public static event Action<IDamageable> OnAttackEvent;
    private void Awake()
    {
        damageables = new List<IDamageable>();

    }
    private void OnEnable()
    {
        AttackRadiusInteraction.OnAddEnemyToDamageableList += AddEnemyToDamageableList;
        AttackRadiusInteraction.OnRemoveEnemyFromDamageableList += RemoveEnemyFromDamageableList;
    }
    private void OnDisable()
    {
        AttackRadiusInteraction.OnAddEnemyToDamageableList -= AddEnemyToDamageableList;
        AttackRadiusInteraction.OnRemoveEnemyFromDamageableList -= RemoveEnemyFromDamageableList;

    }
    private void AddEnemyToDamageableList(Collider other)
    {

        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            Debug.Log("Idamageable added");
            damageables.Add(damageable);
            if (attackCoroutine == null)
            {
                attackCoroutine = StartCoroutine(Attack());
            }
        }


    }
    private void RemoveEnemyFromDamageableList(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            Debug.Log("Idamageable removed");
            damageables.Remove(damageable);
            if (damageables.Count == 0)
            {
                StopCoroutine(attackCoroutine);
                attackCoroutine = null;
            }
        }
    }
    private IEnumerator Attack()
    {
        WaitForSeconds wait = new WaitForSeconds(attackDelay);
        IDamageable closestDamageable = null;
        float closestDistance = minDistanceToAttack;
        while (damageables.Count > 0)
        {

            for (int i = 0; i < damageables.Count; i++)
            {
                Transform damageableTransform = damageables[i].GetTransform();
                float distanceToTarget = Vector3.Distance(transform.position, damageableTransform.position);
                if (distanceToTarget < closestDistance)
                {
                    closestDistance = distanceToTarget;
                    closestDamageable = damageables[i];
                    Debug.Log("Attack");
                }
            }

            if (closestDamageable != null)
            {
                // TO DO: ATTACK EVENTS
                OnAttackEvent?.Invoke(closestDamageable);
            }
            closestDamageable = null;
            closestDistance = minDistanceToAttack;
            yield return wait;
            damageables.RemoveAll(DisabledDamageables);

        }
        attackCoroutine = null;
    }
    private bool DisabledDamageables(IDamageable damageable)
    {
        return damageable != null && !damageable.GetTransform().gameObject.activeSelf;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, minDistanceToAttack);
    }
}
