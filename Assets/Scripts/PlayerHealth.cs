using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public TextMeshProUGUI healthText;

    void Start()
    {
        currentHealth = maxHealth;
        healthText.text = currentHealth.ToString();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthText.text = currentHealth.ToString();

        if (currentHealth < 1)
        {
            healthText.text = "X";
        }
    }
}
