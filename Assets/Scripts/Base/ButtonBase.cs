using System.Collections;
using System.Collections.Generic;
using UniRx.Triggers;
using UniRx;
using UnityEngine;
using Zenject;
using UnityEngine.UI;
using TMPro;

public abstract class ButtonBase : MonoBehaviour
{
    [Inject] protected PlayerHealth playerHealth;
    [Inject] protected GoldCounterManager goldCounterManager;
    [SerializeField] protected TMP_Text priceText,skillValueText;
    [SerializeField] protected float priceValue,skillAmount;
    protected CompositeDisposable subscriptions = new CompositeDisposable();
    protected Button button;
  
    protected virtual void Awake()
    {
        priceText.text=priceValue.ToString();
        skillValueText.text=skillAmount.ToString();
        button = GetComponent<Button>();
    }
    protected virtual void OnEnable()
    {
        StartCoroutine(Subscribe());

    }
    protected virtual void OnDisable()
    {

        subscriptions.Clear();
    }

    private void Start()
    {
        button.onClick.AddListener(OnButtonClickEvent);
     
    }
  
    protected abstract void OnButtonClickEvent();
    protected virtual IEnumerator Subscribe()
    {
        yield return null;

        this.UpdateAsObservable().Subscribe(x =>
        {
            ButtonInteractability();

        })
            .AddTo(subscriptions);
    }

    protected virtual void ButtonInteractability()
    {
        if (goldCounterManager.totalGoldAmount <= 0 || float.Parse(priceText.text)>goldCounterManager.totalGoldAmount
            || playerHealth.Health<=0)
        {
            IsButtonInteractable(false);
        }
        else
        {
           
            IsButtonInteractable(true);
        }

    }
    protected void OnPurchaseSkillEvent()
    {
        goldCounterManager.GoldCounter(-priceValue);
    }
    protected virtual void IsButtonInteractable(bool state)
    {
        button.interactable = state;
    }
}
