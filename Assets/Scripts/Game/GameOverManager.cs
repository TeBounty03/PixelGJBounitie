using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    //public GameObject gameOverPanel;
    public Text gameOverText;
    public Button restartButton;
    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas.SetActive(false); // Assurez-vous que le panneau est désactivé au démarrage
        restartButton.onClick.AddListener(RestartGame);
    }

    public void DisplayGameOver(string message)
    {
        gameOverCanvas.SetActive(true);
        gameOverText.text = message;
    }
    void RestartGame()
    {
        // Logique pour redémarrer le jeu, par exemple recharger la scène
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
