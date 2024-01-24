using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UniRx.Triggers;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    [SerializeField] private GameObject goldPrefab;
    [SerializeField] private int totalGoldAmount=0;
    private void OnEnable()
    {
        EnemyHealth.OnGenerateGoldEvent += GenerateGold;
    }
    private void OnDisable()
    {
        EnemyHealth.OnGenerateGoldEvent -= GenerateGold;

    }

    private void GenerateGold(GameObject gameObject)
    {
        totalGoldAmount++;
        GameObject gold = Instantiate(goldPrefab);
        gold.transform.SetParent(transform);
        gold.transform.DOJump(new Vector3(gameObject.transform.position.x,0.5f,gameObject.transform.position.z), 2, 1, 0.5f)
            .SetEase(Ease.InSine);
        gold.transform.position =gameObject.transform.position;
        gold.transform.rotation = Quaternion.Euler(90,0,0);

    }
}
