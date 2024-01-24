using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour,IDamageable
{
    [SerializeField] private Image healthBar;
    [SerializeField] internal float _health;
    public static event Action<Collider> OnRemoveEnemyFromDamageableList;
    public static event Action<int> OnScoreCounterEvent;
    public static event Action<GameObject> OnGenerateGoldEvent;
    public float Health
    {
        get { return _health; }
        set { _health = value; }
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
            OnScoreCounterEvent?.Invoke(1);
            Debug.Log("DEAD"); 
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
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
        OnGenerateGoldEvent?.Invoke(gameObject);

    }
    

}
