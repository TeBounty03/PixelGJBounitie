using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    //public GameObject gameOverPanel;
    public Text gameOverText;
    public Button restartButton;
    private bool isGameOver = false;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        gameOverCanvas.SetActive(false); // Assurez-vous que le panneau est désactivé au démarrage
        restartButton.onClick.AddListener(RestartGame);
    }

    public void DisplayGameOver(string message)
    {
        gameOverCanvas.SetActive(true);
        gameOverText.text = message;
        Time.timeScale = 0f;
        isGameOver = true;
        
    }
    void RestartGame()
    {
        if (isGameOver)
        {
            Time.timeScale = 1f;
            // Logique pour retourner au menu principale
            DestroyPlayers();
            SceneManager.LoadScene("Menu");
        }
    }
    private void DestroyPlayers()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            Destroy(player);
        }
    }
}
