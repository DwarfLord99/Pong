using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI playerScore;

    void Start()
    {
        UpdateScore(0);
    }

    public void UpdateScore(int score)
    {
        playerScore.text = score.ToString();
    }
}
