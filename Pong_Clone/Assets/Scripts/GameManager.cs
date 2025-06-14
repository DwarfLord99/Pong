using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] ScoreManager scoreManager;
    [SerializeField] GameObject pongBallPrefab;

    private int score = 0;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this GameManager across scenes
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }

        GameStart();
    }

    public void GameStart()
    {
        // At start of game, instantiate the PongBall
        if (pongBallPrefab != null)
        {
            Instantiate(pongBallPrefab, Vector2.zero, Quaternion.identity);
        }
        else
        {
            Debug.LogError("PongBall prefab is not assigned in GameManager.");
        }
    }

    IEnumerator WaitForRespawn()
    {
        yield return new WaitForSeconds(1.0f); // Wait for 1 second before respawning
        GameStart();
    }

    public void RespawnPongBall()
    {
        StartCoroutine(WaitForRespawn());
    }

    public void ScoreUpdate(int Amount)
    {
        score += Amount;
        Debug.Log("Score Updated to " + score);
        if (scoreManager != null)
        {
            scoreManager.UpdateScore(score);
        }
        else
        {
            Debug.LogWarning("ScoreManager is not assigned in GameManager.");
        }
    }
}
