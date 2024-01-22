using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab;
    internal bool willSpawnTargets=true;
    private static float SpawnInterval => 4f * Mathf.Pow(0.95f,2 /*ArcheryGame.CurrentScore*/);

    private void Start()
    {
        StartCoroutine(SpawnTargetsCoroutine());
    }
    private IEnumerator SpawnTargetsCoroutine()
    {
        // Wait a little bit after hitting the first target until we spawn the second one
        yield return new WaitForSeconds(1f);

        while (willSpawnTargets)
        {
            GameObject spawnedTarget = Instantiate(zombiePrefab, GetRandomSpawnPosition(), Quaternion.identity);
            //spawnedTarget.willAttack = true;
            //ArcheryGame.NotifyTargetWasSpawned(spawnedTarget);

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
