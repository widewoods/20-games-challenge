using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    [SerializeField] float ARENA_BOUNDARY_X = 9;
    [SerializeField] private int winScore = 10;

    [Header("References")]
    [SerializeField] private Transform ball;
    [SerializeField] private TextMeshProUGUI leftScoreText;
    [SerializeField] private TextMeshProUGUI rightScoreText;
    [SerializeField] private Transform leftSpawnPoint;
    [SerializeField] private Transform rightSpawnPoint;

    public static Action OnBallRespawn;


    private int leftScore = 0;
    private int rightScore = 0;

    void OnEnable()
    {
        leftScoreText.SetText("{0}", leftScore);
        rightScoreText.SetText("{0}", rightScore);
    }

    void Update()
    {
        if (ball) CheckPassedArena();
    }

    void HandleScore(int player)
    {
        if (player == 0)
        {
            leftScore += 1;
            leftScoreText.SetText("{0}", leftScore);
        }
        else if (player == 1)
        {
            rightScore += 1;
            rightScoreText.SetText("{0}", rightScore);
        }

        if (leftScore >= winScore)
        {
            HandleWin(0);
        }
        else if (rightScore >= winScore)
        {
            HandleWin(1);
        }
        else // Respawn when score is less than the score goal.
        {
            RespawnBall(player);
        }
    }

    void RespawnBall(int lastScorer)
    {
        ball.position = lastScorer == 0 ? rightSpawnPoint.position : leftSpawnPoint.position;
        OnBallRespawn?.Invoke();
    }

    void HandleWin(int player)
    {
        Destroy(ball.gameObject);
    }

    void CheckPassedArena()
    {
        // Left player scores
        if (ball.position.x > ARENA_BOUNDARY_X)
        {
            HandleScore(0);
        }
        // Right player scores
        else if (ball.position.x < -ARENA_BOUNDARY_X)
        {
            HandleScore(1);
        }
    }
}
