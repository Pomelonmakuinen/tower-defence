using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = startHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
