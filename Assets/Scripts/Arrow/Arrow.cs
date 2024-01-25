using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject.SpaceFighter;

public class Arrow : MonoBehaviour
{
    private Vector3 startPosition, finalLookDirection;
    private float conquaredDistance;
    internal float arrowDamage;
    private Rigidbody rb;
    [SerializeField] private float maxDistance,arrowSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        conquaredDistance = Vector3.Distance(transform.position, startPosition);
        if (conquaredDistance >= maxDistance)
        {
            DisableGameObject();
        }

    }

    private void DisableGameObject()
    {
        rb.velocity = Vector3.zero;
        this.gameObject.SetActive(false);
    }

    internal void InitializeArrow(IDamageable damageable)
    {
        startPosition = transform.position;
        Vector3 direction = (damageable.GetTransform().position - startPosition).normalized; 
        direction.y = 0f;
        rb.velocity = direction * arrowSpeed;
    }
    internal void Aim(IDamageable damageable)
    {

        var rotationSpeed = arrowSpeed * Time.deltaTime;
        Vector3 direction = damageable.GetTransform().position - transform.position;
        finalLookDirection = Vector3.Lerp(finalLookDirection, direction, rotationSpeed);
        transform.rotation = Quaternion.LookRotation(finalLookDirection);
    }

}
