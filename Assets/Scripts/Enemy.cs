using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startHealth = 100f;
    private float currentHealth;

    public int rewardAmount = 10;

    void Start()
    {
        currentHealth = startHealth;
    }

    public void TakeDamage(float amount)
    {
        Debug.Log($"Enemy took {amount} damage. Health now: {currentHealth - amount}");
        currentHealth -= amount;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }


    void Die()
    {
        PlayerStats.Money += rewardAmount;
        Destroy(gameObject);
    }
}
