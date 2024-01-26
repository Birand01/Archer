using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class GoldMovement : MonoBehaviour
{
   
    [SerializeField] private float rotationSpeed;
    protected CompositeDisposable subscriptions = new CompositeDisposable();
    private Transform _player;
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void OnEnable()
    {
        
        StartCoroutine(MoveToPlayer());
        StartCoroutine(Subscribe());
       
    }
    private void OnDisable()
    {
      

        subscriptions.Clear();
    }
    private void RotateGold()
    {
        transform.Rotate(new Vector3(transform.position.x,transform.position.y,rotationSpeed)*Time.deltaTime);
    }

   
    private IEnumerator MoveToPlayer()
    {
        yield return new WaitForSeconds(1f);
        transform.DOMove(_player.position,0.5f).SetEase(Ease.OutQuad);
       
    }
    protected virtual IEnumerator Subscribe()
    {
        yield return null;

        this.UpdateAsObservable().Subscribe(x =>
        {
            RotateGold();
          
        })
            .AddTo(subscriptions);
    }

}
