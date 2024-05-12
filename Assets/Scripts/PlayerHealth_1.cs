using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth_1 : MonoBehaviour
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
            foreach (Transform child in canvas.transform)
            {
                GameObject childObject = child.gameObject;

                if (childObject != null && childObject.name.Contains("1"))
                {
                    // Recherchez le composant TextMeshProUGUI dans l'objet Image
                    healthText = childObject.GetComponentInChildren<TextMeshProUGUI>();

                    if (healthText != null)
                    {
                        // Faites quelque chose avec le TextMeshProUGUI trouvé
                        Debug.Log("TextMeshProUGUI P1 trouvé !");
                    }
                    else
                    {
                        Debug.LogError("TextMeshProUGUI P1 non trouvé dans l'objet Image.");
                    }
                }
                else
                {
                    Debug.LogError("Image P1 non trouvée dans le Canvas.");
                }
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
