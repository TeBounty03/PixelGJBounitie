using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //public GameObject pauseMenuUI; // Référence au panel Menu Pause
    public GameObject pauseMenuCanvas;
    private bool isPaused = false;

    void Start()
    {
        // S'assurer que le menu de pause est désactivé au démarrage de la scène
        pauseMenuCanvas.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }

    public void Resume()
    {
        pauseMenuCanvas.SetActive(false); // Désactive le menu pause
        Time.timeScale = 1f; // Reprend le temps normal
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuCanvas.SetActive(true); //Active le menu de pause
        Time.timeScale = 0f; // Met le jeu en pause
        isPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        // Détruire les joueurs instanciés
        DestroyPlayers();
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Méthode pour détruire les joueurs instanciés
    private void DestroyPlayers()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            Destroy(player);
        }
    }
}
