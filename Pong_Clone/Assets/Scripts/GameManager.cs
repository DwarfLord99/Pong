using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // This variable will hold the score
    [SerializeField] ScoreManager scoreManager;

    private int score = 0;

    void Start()
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
    }

    void Update()
    {
        
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
