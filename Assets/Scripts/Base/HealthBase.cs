using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class HealthBase : MonoBehaviour,IDamageable
{
    [SerializeField] private Image healthBar;
    [SerializeField] private float _health;
    public float Health
    {
        get { return _health; }
        set { _health = value; }
    }

    protected abstract void ObjectDeadEvent();


    public Transform GetTransform()
    {
        return transform;
    }

    public void TakeDamage(float damage)
    {
        healthBar.fillAmount -= damage / Health;
        healthBar.fillAmount = Mathf.Clamp(healthBar.fillAmount, 0, 1);
        CheckIfDead();
    }
    private void CheckIfDead()
    {
        if (healthBar.fillAmount <= 0)
        {
            Debug.Log("DEAD");
            ObjectDeadEvent();
        }
    }
}
