using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private Text healthText;
    private PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (playerHealth != null && healthText != null)
        {
            var _health = playerHealth.GetHealth();
            healthText.text = _health.ToString();
            //TODO: Use StringBuilder.
        }
    }
}
