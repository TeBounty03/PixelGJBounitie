using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject playerPrefab_1;
    public GameObject playerHeart_1;
    public GameObject playerPrefab_2;
    public GameObject playerHeart_2;
    public Canvas canvas;
    public GameOverManager gameOverManager; // Référence au GameOverManager
    private GameObject player1;
    private GameObject player2;

    void Start()
    {
        int numberOfPlayers = PlayerPrefs.GetInt("NumberOfPlayers", 1);
        if (numberOfPlayers == 1)
        {
            // Instancier le premier joueur
            Instantiate(playerHeart_1, new Vector3(40, 50, 50), Quaternion.identity, canvas.transform);
            player1 = Instantiate(playerPrefab_1, Vector3.zero, Quaternion.identity);
            player1.GetComponent<PlayerHealth_1>().onDestroyed += OnPlayerDestroyed;

        }
        else if (numberOfPlayers == 2)
        {
            Instantiate(playerHeart_1, new Vector3(40, 400, 50), Quaternion.identity, canvas.transform);
            // Instancier le premier joueur
            player1 = Instantiate(playerPrefab_1, new Vector3(-1, 0, 0), Quaternion.identity);
            player1.GetComponent<PlayerHealth_1>().onDestroyed += OnPlayerDestroyed;

            Instantiate(playerHeart_2, new Vector3(40, 200, 50), Quaternion.identity, canvas.transform);
            // Instancier le deuxième joueur
            player2 = Instantiate(playerPrefab_2, new Vector3(1, 0, 0), Quaternion.identity);
            player2.GetComponent<PlayerHealth_2>().onDestroyed += OnPlayerDestroyed;
        }
    }

    void OnPlayerDestroyed(GameObject destroyedPlayer)
    {
        Time.timeScale = 0f; // Met le jeu en pause
        if (player2 == null)
        {
            gameOverManager.DisplayGameOver("Game Over! You lost.");
        }
        else
        {
            if (destroyedPlayer == player1)
            {
                gameOverManager.DisplayGameOver("Player 2 wins");
            }
            else if (destroyedPlayer == player2)
            {
                gameOverManager.DisplayGameOver("Player 1 wins");
            }
        }
    }
}
