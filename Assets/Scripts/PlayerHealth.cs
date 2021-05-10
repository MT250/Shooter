using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    [SerializeField] private float maxHealth;
    private float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void Damage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0) Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    public float GetHealth()
    {
        return currentHealth;
    }
}
