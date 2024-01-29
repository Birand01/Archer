using DG.Tweening;
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
    public static event Action OnAttackAnimationEvent;
    public static event Action<ParticleType, Vector3> OnAttackRangeParticle;

    private void Awake()
    {
        damageables = new List<IDamageable>();
        minDistanceToAttack = 2 * this.transform.localScale.x;
    }

    private void UpdateAttackRange(float range)
    {
        OnAttackRangeParticle?.Invoke(ParticleType.AttackRange, transform.position);
        transform.DOScale(transform.localScale.x + range, 0.5f);
        StartCoroutine(ColorCoroutine());
        minDistanceToAttack+=2*range;
    }
    private IEnumerator ColorCoroutine()
    {
        this.gameObject.GetComponent<SpriteRenderer>().DOColor(Color.blue, 0.5f);
        yield return new WaitForSeconds(0.2f);
        this.gameObject.GetComponent<SpriteRenderer>().DOColor(Color.white, 0.5f);

    }



    private void OnEnable()
    {
        AttackRangeButton.OnIncreaseAttackRangeEvent += UpdateAttackRange;
        PlayerHealth.OnPlayerDeadEvent += OnDeadEvent;
        EnemyHealth.OnRemoveEnemyFromDamageableList += RemoveEnemyFromDamageableList;
        AttackRadiusInteraction.OnAddEnemyToDamageableList += AddEnemyToDamageableList;
        AttackRadiusInteraction.OnRemoveEnemyFromDamageableList += RemoveEnemyFromDamageableList;
    }
    private void OnDisable()
    {
        AttackRangeButton.OnIncreaseAttackRangeEvent -= UpdateAttackRange;
        AttackRadiusInteraction.OnAddEnemyToDamageableList -= AddEnemyToDamageableList;
        AttackRadiusInteraction.OnRemoveEnemyFromDamageableList -= RemoveEnemyFromDamageableList;
        EnemyHealth.OnRemoveEnemyFromDamageableList -= RemoveEnemyFromDamageableList;
        PlayerHealth.OnPlayerDeadEvent -= OnDeadEvent;

    }
    private void AddEnemyToDamageableList(Collider other)
    {

        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
           // Debug.Log("Idamageable added");
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
           // Debug.Log("Idamageable removed");
            damageables.Remove(damageable);
           
            if (damageables.Count == 0)
            {
                StopCoroutine(attackCoroutine);
                attackCoroutine = null;
            }
        }
    }
    private void OnDeadEvent(bool state)
    {
        if (state)
        {
            gameObject.GetComponent<Collider>().isTrigger = false;
           
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
                   
                }
            }

            if (closestDamageable != null)
            {
                // TO DO: ATTACK EVENTS
                OnAttackAnimationEvent?.Invoke();
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
