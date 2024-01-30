using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EnemyHealth : MonoBehaviour,IDamageable
{
    [SerializeField] private GameObject goldPrefab;
    [SerializeField] private Image healthBar;
    internal float _health,goldGive;
    internal float takenDamage;

    /// <summary>
    /// EVENTS
    /// </summary>
    public static event Action<Collider> OnRemoveEnemyFromDamageableList;
    public static event Action<int> OnScoreCounterEvent;
    public static event Action OnPurchaseBoostArrowDamageEvent;
    public static event Action<ParticleType, Vector3> OnEnemyDeadParticle;

    // -----------------------------------------------------


    public float Health
    {
        get { return _health; }
        set { _health = value; }
    }

    private void OnEnable()
    {
        ArrowDamageButton.OnIncreaseArrowDamageEvent += OnIncreaseTakenDamageValue;
    }
    private void OnDisable()
    {
        ArrowDamageButton.OnIncreaseArrowDamageEvent -= OnIncreaseTakenDamageValue;

    }

    private void OnIncreaseTakenDamageValue(float value)
    {
        gameObject.GetComponent<EnemyConfiguration>().enemySO.takenDamage += value;
        OnPurchaseBoostArrowDamageEvent?.Invoke();
    }

    public Transform GetTransform()
    {
        return transform;
    }
    
    
    public virtual void TakeDamage(float damage)
    {
        healthBar.fillAmount -= damage / Health;
        healthBar.fillAmount = Mathf.Clamp(healthBar.fillAmount, 0, Health);
        CheckIfDead();
    }
    private void CheckIfDead()
    {
        if (healthBar.fillAmount <= 0)
        {
            Health = 0;
            StartCoroutine(GenerateGold());
            OnScoreCounterEvent?.Invoke(1);
            ObjectDeadEvent();
        }
    }
    private void ObjectDeadEvent()
    {
        StartCoroutine(DeadEventCoroutine());
    }
    private IEnumerator DeadEventCoroutine()
    {
        OnRemoveEnemyFromDamageableList?.Invoke(this.GetComponent<Collider>());
        gameObject.GetComponent<Collider>().enabled = false;
        OnEnemyDeadParticle?.Invoke(ParticleType.EnemyDead, transform.position);      
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
    }
    private IEnumerator GenerateGold()
    {
        yield return new WaitForSeconds(1);
        GameObject gold =Instantiate(goldPrefab);
        gold.transform.position = transform.position;
        gold.transform.rotation = Quaternion.Euler(90, 0, 0);
        gold.gameObject.GetComponent<GoldInteraction>().goldGive = goldGive;
        gold.transform.DOJump(new Vector3(transform.position.x, 0.6f, transform.position.z), 2, 1, 0.5f)
            .SetEase(Ease.InSine);
        
    }

}
