using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public TextMeshProUGUI healthText;

    void Start()
    {
        //Cette partie sert à trouver le texte des points de vie et à le lier à "healthText"
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas != null)
        {
            // Recherchez l'objet Image dans le Canvas
            Image image = canvas.GetComponentInChildren<Image>();

            if (image != null && image.name == "Heart_1")
            {
                // Recherchez le composant TextMeshProUGUI dans l'objet Image
                healthText = image.GetComponentInChildren<TextMeshProUGUI>();

                if (healthText != null)
                {
                    // Faites quelque chose avec le TextMeshProUGUI trouvé
                    Debug.Log("TextMeshProUGUI trouvé !");
                }
                else
                {
                    Debug.LogError("TextMeshProUGUI non trouvé dans l'objet Image.");
                }
            }
            else
            {
                Debug.LogError("Image non trouvée dans le Canvas.");
            }
        }
        else
        {
            Debug.LogError("Canvas non trouvé dans la scène.");
        }


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
