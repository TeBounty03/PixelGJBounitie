using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject playerPrefab;

    void Start()
    {
        int numberOfPlayers = PlayerPrefs.GetInt("NumberOfPlayers", 1);
        if (numberOfPlayers == 1)
        {
            // Instancier le premier joueur
            Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        }
        else if (numberOfPlayers == 2)
        {
            // Instancier le premier joueur
            Instantiate(playerPrefab, new Vector3(-1, 0, 0), Quaternion.identity);
            // Instancier le deuxième joueur
            Instantiate(playerPrefab, new Vector3(1, 0, 0), Quaternion.identity);
        }
        
    }
}
