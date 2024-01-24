using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable, IHealable
{
    [SerializeField] private Slider healthBarSlider;
    [SerializeField] private Image healthFillbarImage;
    [SerializeField] private Color initialHealthColor, finalHealthColor;
    [SerializeField] private TMP_Text currentHealthText, maxHealthText;
    [SerializeField] internal float totalSize;
    internal float remainingSize;

    public static event Action<bool> OnPlayerDeadEvent;
    public static event Action OnGameOverEvent;
    internal float Health
    {
        get
        {
            return remainingSize;
        }
        set
        {
            remainingSize = value;
        }
    }
    private void OnEnable()
    {
        DamageZoneInteraction.OnTakeDamageFromPlayer += TakeDamage;
    }
    private void OnDisable()
    {
        DamageZoneInteraction.OnTakeDamageFromPlayer -= TakeDamage;

    }
    protected  void Start()
    {
        remainingSize = totalSize;
        SetHealthbarUI();
        InitializeHealthTexts();
        healthBarSlider.maxValue = totalSize;
        healthBarSlider.value = totalSize;
    }
    private void InitializeHealthTexts()
    {
        currentHealthText.text = Health.ToString();
        maxHealthText.text = totalSize.ToString();
    }
    public void GainHealth(float value)
    {
        Health += value;
        currentHealthText.text=Health.ToString();
        Health = Mathf.Clamp(Health, 0, totalSize);
    }
    public void TakeDamage(float damage)
    {
        Health -= damage;
        Health = Mathf.Clamp(Health, 0, totalSize);
        currentHealthText.text = String.Format("{0:0}", Health);
        if (Health <= 0)
        {
            OnGameOverEvent?.Invoke();
            OnPlayerDeadEvent?.Invoke(true);
        }
        SetHealthbarUI();
    }
    private void SetHealthbarUI()
    {
        float healthPercentage = CalculateHealthBarPercentage();
        healthBarSlider.value = healthPercentage;
        healthFillbarImage.color = Color.Lerp(finalHealthColor, initialHealthColor, healthPercentage / healthBarSlider.maxValue);
    }
    private float CalculateHealthBarPercentage()
    {
        return ((float)(Health) / (float)totalSize) * healthBarSlider.maxValue;
    }

    public Transform GetTransform()
    {
        return transform;
    }

   
}
