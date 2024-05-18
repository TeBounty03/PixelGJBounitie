using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject playerPrefab_1;
    public GameObject playerHeart_1;
    public GameObject playerPrefab_2;
    public GameObject playerHeart_2;
    public Canvas canvas;
    public GameObject pauseMenuCanvas;

    void Start()
    {
        int numberOfPlayers = PlayerPrefs.GetInt("NumberOfPlayers", 1);
        if (numberOfPlayers == 1)
        {
            // Instancier le premier joueur
            Instantiate(playerHeart_1, new Vector3(40, 50, 50), Quaternion.identity, canvas.transform);
            Instantiate(playerPrefab_1, Vector3.zero, Quaternion.identity);

        }
        else if (numberOfPlayers == 2)
        {
            Instantiate(playerHeart_1, new Vector3(40, 400, 50), Quaternion.identity, canvas.transform);
            // Instancier le premier joueur
            Instantiate(playerPrefab_1, new Vector3(-1, 0, 0), Quaternion.identity);

            Instantiate(playerHeart_2, new Vector3(40, 200, 50), Quaternion.identity, canvas.transform);
            // Instancier le deuxième joueur
            Instantiate(playerPrefab_2, new Vector3(1, 0, 0), Quaternion.identity);
        }

    }
}
