using System.Collections;
using System.Collections.Generic;
using UniRx.Triggers;
using UniRx;
using UnityEngine;

public abstract class InteractionBase : MonoBehaviour
{
    private CompositeDisposable _disposable = new CompositeDisposable();

    protected Collider _collider = null;

    protected virtual void OnTriggerStayAction(Collider other) { }
    protected virtual void OnTriggerExitAction(Collider other) { }
    protected virtual void OnTriggerEnterAction(Collider collider) { }

    private void Reset()
    {

        
    }
    protected virtual void Awake()
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
    }
    protected virtual void Start()
    {
        OnTriggerEnterSubscription();
        OnTriggerExitSubscription();
        OnTriggerStaySubscription();
    }
    private void OnTriggerStaySubscription()
    {
        _collider.OnTriggerStayAsObservable().Subscribe(other =>
        {
            OnTriggerStayAction(other);
        }).AddTo(_disposable);
    }

    private void OnTriggerEnterSubscription()
    {
        _collider.OnTriggerEnterAsObservable().Subscribe(other =>
        {
            OnTriggerEnterAction(other);
        }).AddTo(_disposable);

    }

    private void OnTriggerExitSubscription()
    {
        _collider.OnTriggerExitAsObservable().Subscribe(other =>
        {
            OnTriggerExitAction(other);
        }).AddTo(_disposable);
    }

    protected virtual void OnDisable()
    {
        _disposable.Clear();

    }


}
