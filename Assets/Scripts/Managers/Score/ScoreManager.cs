using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] internal int totalScore = 0;
    private void OnEnable()
    {
        EnemyHealth.OnScoreCounterEvent += ScoreCounter;
    }
    private void OnDisable()
    {
        EnemyHealth.OnScoreCounterEvent -= ScoreCounter;

    }

    private void ScoreCounter(int killToAdd)
    {
        totalScore += killToAdd;
        scoreText.text = totalScore.ToString();
    }
}
