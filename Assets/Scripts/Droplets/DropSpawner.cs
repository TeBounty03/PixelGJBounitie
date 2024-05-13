using System.Collections;
using UnityEngine;

public class DropSpawner : MonoBehaviour
{
    public GameObject dropPrefab;
    public Camera mainCamera;
    public float spawnInterval =  1f;

    private Rigidbody2D rb;
    public float waitTime = 2f;

    void Start()
    {
        // Récupérer la taille de la caméra pour calculer la position en haut
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        // Calculer une position aléatoire en haut de la caméra
        float randomX = Random.Range(-cameraWidth / 2f, cameraWidth / 2f);
        Vector3 spawnPosition = new Vector3(
            mainCamera.transform.position.x + randomX,
            mainCamera.transform.position.y + (cameraHeight / 2f),
            0f
        );

        // Instancier la goutte à la position calculée
        GameObject instantiatedPrefab = Instantiate(dropPrefab, spawnPosition, Quaternion.identity);
        Rigidbody2D instantiatedRb = instantiatedPrefab.GetComponent<Rigidbody2D>();
        if (instantiatedRb != null)
        {
            Debug.Log("Prefab Rigidbody2D" + instantiatedRb.name);
            rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
            Debug.Log("FreezePositionY" + rb.constraints);
        }
        else
        {
            Debug.LogWarning("Le prefab ne contient pas de composant Rigidbody2D.");
        }
    }

}
