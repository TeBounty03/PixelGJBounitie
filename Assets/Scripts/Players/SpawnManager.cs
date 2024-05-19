using UnityEngine;
using System.Collections;

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
    private bool isPlayer1Alive;
    private bool isPlayer2Alive;
    private bool gameOverHandled = false;

    void Start()
    {
        InitializePlayers();
    }

    void InitializePlayers()
    {
        int numberOfPlayers = PlayerPrefs.GetInt("NumberOfPlayers", 1);
        isPlayer1Alive = true;
        isPlayer2Alive = numberOfPlayers == 2;
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
        if (gameOverHandled) return; // S'assurer que le Game Over n'est géré qu'une seule fois

        if (destroyedPlayer == player1)
        {
            isPlayer1Alive = false;
            player1 = null; // Marquer le joueur comme détruit
        }
        else if (destroyedPlayer == player2)
        {
            isPlayer2Alive = false;
            player2 = null; // Marquer le joueur comme détruit
        }

        StartCoroutine(HandleGameOver());
    }

    private IEnumerator HandleGameOver()
    {
        yield return new WaitForSeconds(0.1f); // Attendre un court délai pour gérer les destructions simultanées
        if (!isPlayer1Alive && player2 == null)
        {
            gameOverManager.DisplayGameOver("Game Over! You lost.");
        }
        else
        {
            if (!isPlayer1Alive && !isPlayer2Alive)
            {
                gameOverManager.DisplayGameOver("Both players lost!");
            }
            else if (!isPlayer1Alive && player2 != null)
            {
                gameOverManager.DisplayGameOver("Player 2 wins");
            }
            else if (!isPlayer2Alive && player1 != null)
            {
                gameOverManager.DisplayGameOver("Player 1 wins");
            }
        }

        gameOverHandled = true;
    }
}
