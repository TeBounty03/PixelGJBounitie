using UnityEngine;
using UnityEngine.UI;

public class Background_Menu : MonoBehaviour
{
    private Image backgroundImage;
    void Start()
    {
        backgroundImage = GetComponent<Image>();
        ResizeToScreen();
    }

    void ResizeToScreen()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // Récupérer la taille native de l'image
        float imageWidth = backgroundImage.sprite.texture.width;
        float imageHeight = backgroundImage.sprite.texture.height;

        // Calculer le ratio de redimensionnement
        float ratioWidth = screenWidth / imageWidth;
        float ratioHeight = screenHeight / imageHeight;

        // Sélectionner le plus petit ratio pour ne pas déformer l'image
        float ratio = Mathf.Min(ratioWidth, ratioHeight);

        // Calculer la nouvelle taille de l'image
        float newWidth = imageWidth * ratio;
        float newHeight = imageHeight * ratio;

        // Mettre à jour la taille de l'image
        backgroundImage.rectTransform.sizeDelta = new Vector2(newWidth, newHeight);
    }
}
