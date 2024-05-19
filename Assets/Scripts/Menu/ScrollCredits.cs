using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrollCredits : MonoBehaviour
{
    public float scrollSpeed = 20f;
    private RectTransform rectTransform;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        rectTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
        // Vérifie si la touche Escape est pressée
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Charge la scène du menu
            SceneManager.LoadScene("Menu");
        }

        // Vérifie si un bouton de la souris est cliqué (le bouton gauche est 0)
        if (Input.GetMouseButtonDown(0))
        {
            // Charge la scène du menu
            SceneManager.LoadScene("Menu");
        }
    }
}
