using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    protected CompositeDisposable subscriptions = new CompositeDisposable();
    public State currentState;
    private void OnEnable()
    {
        StartCoroutine(Subscribe());
    }
    private void OnDisable()
    {
       

        subscriptions.Clear();
    }
    private void OnStartGameEvent()
    {
        
    }
    protected virtual IEnumerator Subscribe()
    {
        yield return null;

        this.UpdateAsObservable().Subscribe(x =>
        {
            RunCurrentState();
        })
            .AddTo(subscriptions);
    }

    private void RunCurrentState()
    {
        State nextState = currentState?.RunCurrentState();
        if (nextState != null)
        {
            SwitchToNextState(nextState);
        }

    }
    private void SwitchToNextState(State nextState)
    {
        currentState = nextState;
    }
}
