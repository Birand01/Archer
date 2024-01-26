using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawnManager : MonoBehaviour
{
    [Inject] ScoreManager scoreManager;
    [SerializeField] private List<GameObject> enemyList=new List<GameObject>();
    internal bool willSpawnTargets=true;
    private float SpawnInterval => 4f * Mathf.Pow(0.95f, 0.1f*scoreManager.totalScore);

    private void Start()
    {
        StartCoroutine(SpawnTargetsCoroutine());
    }
    private void OnEnable()
    {
        PlayerHealth.OnGameOverEvent += GameOverEvent;
    }
    private void OnDisable()
    {
        PlayerHealth.OnGameOverEvent -= GameOverEvent;

    }

    private void GameOverEvent()
    {
        willSpawnTargets = false;
    }
    private IEnumerator SpawnTargetsCoroutine()
    {
        yield return new WaitForSeconds(1f);

        while (willSpawnTargets)
        {
            GameObject spawnedTarget = Instantiate(enemyList[Random.Range(0,enemyList.Count)], GetRandomSpawnPosition(), Quaternion.identity);
            yield return new WaitForSeconds(SpawnInterval);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        int randomIndex = Random.Range(0, transform.childCount);
        return transform.GetChild(randomIndex).position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        for (int i = 0; i < transform.childCount; i++)
        {
            Gizmos.DrawWireSphere(transform.GetChild(i).position, 1f);
        }
    }
}
