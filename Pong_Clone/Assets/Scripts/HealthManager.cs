using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] GameObject heartPrefab;
    [SerializeField] Transform heartContainer; // Parent object to hold heart images
    [SerializeField] Transform enemyHeartContainer; // Parent object for enemy hearts

    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite halfHeart;
    [SerializeField] Sprite halfHeartFlipped;
    [SerializeField] Sprite emptyHeart;

    [SerializeField] int maxHealth = 6; // Each heart piece represents 2 health points
    [SerializeField] int currentPlayerHealth;
    [SerializeField] int currentEnemyHealth;

    private List<Image> heartSprites = new List<Image>();
    private List<Image> enemyHeartSprites = new List<Image>();

    void Start()
    {
        currentPlayerHealth = maxHealth;
        currentEnemyHealth = maxHealth;
        CreateHearts();
    }

    void CreateHearts()
    {
        int heartCount = maxHealth / 2; // Each heart piece represents 2 health points
        for (int i = 0; i < heartCount; i++)
        {
            GameObject heart = Instantiate(heartPrefab, heartContainer);
            Image heartImage = heart.GetComponent<Image>();
            heartSprites.Add(heartImage);

            GameObject enemyHeart = Instantiate(heartPrefab, enemyHeartContainer);
            Image enemyHeartImage = enemyHeart.GetComponent<Image>();
            enemyHeartSprites.Add(enemyHeartImage);
        }
    }

    void UpdateHearts()
    {
        for(int i = 0; i < heartSprites.Count; i++)
        {
            int heartHealth = Mathf.Clamp(currentPlayerHealth - i * 2, 0, 2);
            heartSprites[i].sprite = heartHealth switch
            {
                2 => fullHeart,
                1 => halfHeart,
                _ => emptyHeart,
            };
        }
    }

    void UpdateEnemyHearts()
    {
        for(int i = 0; i < enemyHeartSprites.Count; i++)
        {
            int enemyHeartHealth = Mathf.Clamp(currentEnemyHealth - i * 2, 0, 2);
            enemyHeartSprites[i].sprite = enemyHeartHealth switch
            {
                2 => fullHeart,
                1 => halfHeartFlipped,
                _ => emptyHeart,
            };
        }
    }

    public void TakeDamage(int amount)
    {
        currentPlayerHealth = Mathf.Max(currentPlayerHealth - amount, 0);
        UpdateHearts();
    }

    public void EnemyTakeDamage(int amount)
    {
        currentEnemyHealth = Mathf.Max(currentEnemyHealth - amount, 0);
        UpdateEnemyHearts();
    }

    void Heal()
    {
        // Increase health by 1 heart piece, up to maxHealth
    }
}
