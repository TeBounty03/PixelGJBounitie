using TMPro;
using UnityEngine;
using System;
using System.Collections;

public class PlayerHealth_2 : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public TextMeshProUGUI healthText;
    public bool isHit = false;
    public Animator animator;
    public event Action<GameObject> onDestroyed;

    void Start()
    {
        //Cette partie sert à trouver le texte des points de vie et à le lier à "healthText"
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas != null)
        {
            foreach (Transform child in canvas.transform)
            {
                GameObject childObject = child.gameObject;

                if (childObject != null && childObject.name.Contains("2"))
                {
                    // Recherchez le composant TextMeshProUGUI dans l'objet Image
                    healthText = childObject.GetComponentInChildren<TextMeshProUGUI>();

                    if (healthText != null)
                    {
                        // Faites quelque chose avec le TextMeshProUGUI trouvé
                    }
                    else
                    {
                        Debug.LogError("TextMeshProUGUI P2 non trouvé dans l'objet Image.");
                    }
                }
                else
                {
                    // Debug.LogError("Image P2 non trouvée dans le Canvas.");
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

    void FixedUpdate()
    {
        animator.SetBool("isHit", isHit);
    }

    public void TakeDamage(int damage)
    {
        if (!isHit)
        {
            currentHealth -= damage;
            healthText.text = currentHealth.ToString();

            if (currentHealth < 1)
            {
                healthText.text = "X";
                isHit = true; //si autre animation pour la mort
            }
            else
            {
                isHit = true;
            }

            // Démarrer la coroutine pour réinitialiser isHit après un délai
            StartCoroutine(ResetIsHit());
        }
    }

    private IEnumerator ResetIsHit()
    {
        // Attendre 1 seconde (ou une autre durée)
        yield return new WaitForSeconds(1f);
        isHit = false;
        if (currentHealth < 1)
        {
            onDestroyed?.Invoke(gameObject);// Appeler l'événement avant la destruction
            Destroy(gameObject); 
        }
    }
}
