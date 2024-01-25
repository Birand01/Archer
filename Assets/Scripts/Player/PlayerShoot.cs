using System.Collections;
using System.Collections.Generic;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject.SpaceFighter;

public class PlayerShoot : MonoBehaviour
{
    private CompositeDisposable _disposable = new CompositeDisposable();
    [SerializeField] protected List<Transform> shootPositions;
    [SerializeField] protected GameObject arrowPrefab;
    [SerializeField] protected float reloadDelay;

    private bool canShoot = true;
    private Collider[] playerColliders;
    private float currentDelay = 0f;

    protected virtual void Awake()
    {
        playerColliders = GetComponentsInParent<Collider>();
    }
    private void OnEnable()
    {
        AttackRadius.OnAttackEvent += Shoot;
    }
    private void OnDisable()
    {
        AttackRadius.OnAttackEvent -= Shoot;

        _disposable.Clear();
    }

    protected virtual void Start()
    {
        Observable.EveryUpdate().Subscribe(_ =>
        {
            ShootFrequency();
        }).AddTo(_disposable);
    }
    private void ShootFrequency()
    {
        if (canShoot == false)
        {
            currentDelay -= Time.deltaTime;
            if (currentDelay <= 0f)
            {
                canShoot = true;
            }
        }
    }
   


    private void  Shoot(IDamageable damageable)
    {
        if (canShoot)
        {
            canShoot = false;
            currentDelay = reloadDelay;
            foreach (var barrel in shootPositions)
            {
                GameObject arrow = Instantiate(arrowPrefab);
                arrow.transform.position =new Vector3(barrel.position.x, barrel.position.y+0.3f, barrel.position.z);
                arrow.transform.rotation = Quaternion.LookRotation(damageable.GetTransform().position);
                //arrow.GetComponent<Arrow>().Aim(damageable);
                arrow.GetComponent<Arrow>().InitializeArrow(damageable);
                foreach (var colliders in playerColliders)
                {
                    Physics.IgnoreCollision(arrow.GetComponent<Collider>(), colliders);
                }
            }
        }
    }
}
