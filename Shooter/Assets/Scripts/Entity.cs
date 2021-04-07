using UnityEngine;

public class Entity : MonoBehaviour, IDamagable
{
    [SerializeField] private float health;
    [Space(10), SerializeField]
    private Transform destroyedPrefab;

    public void Damage(float amount)
    {
        //Reduce health amount
        health -= amount;
        //Destroy object if health drops below zero
        if (health <= 0)
        {
            Destroy(gameObject);
            if (destroyedPrefab != null)
            {
                Instantiate(destroyedPrefab, this.transform.position, Quaternion.identity);
            }
        }
    }
}
