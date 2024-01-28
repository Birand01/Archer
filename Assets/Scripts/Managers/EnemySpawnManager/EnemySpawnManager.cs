using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawnManager : MonoBehaviour
{
    [Inject] KillCounterManager scoreManager;
    [SerializeField] private List<Zombie> monsterList=new List<Zombie>();
    internal bool willSpawnTargets=true;
    private float SpawnInterval => 4f * Mathf.Pow(0.95f, 0.1f*scoreManager.totalScore);
    private double accumulatedWeights;
    private System.Random rand=new System.Random();
    private void Awake()
    {
        CalculateWeights();
    }
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
            Zombie randomZombie = monsterList[GetRandomMonsterIndex()];
            GameObject spawnedTarget = Instantiate(randomZombie.enemyPrefab);
            spawnedTarget.transform.position=GetRandomSpawnPosition();
            spawnedTarget.transform.rotation=Quaternion.identity;
            yield return new WaitForSeconds(SpawnInterval);
        }
    }
    private int GetRandomMonsterIndex()
    {
        double r=rand.NextDouble()*accumulatedWeights;
        for (int i = 0; i < monsterList.Count; i++)
        {
            if (monsterList[i]._weight>=r)
            {
                return i;
            }
        }
        return 0;

    }

    private void CalculateWeights()
    {
        accumulatedWeights = 0f;
        foreach (Zombie zombie in monsterList)
        {
            accumulatedWeights += zombie.spawnChance;
            zombie._weight = accumulatedWeights;
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
[System.Serializable]
public class Zombie
{
    public GameObject enemyPrefab;
    [Range(0f, 100f)] public float spawnChance;
    [HideInInspector] public double _weight;
}
