using UnityEngine;

public class DropSpawner : MonoBehaviour
{
    public GameObject dropPrefab;
    public Camera mainCamera;
    private GameObject instantiatedPrefab;
    public float initialSpawnInterval = 1f;
    public float maxSpawnRate = 0.1f; // Le taux de spawn maximal
    public float spawnRateIncreasePerSecond = 0.01f; // L'augmentation du taux de spawn par seconde
    private float currentSpawnInterval;

    void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        InvokeRepeating("DropRandomPosition", 0f, currentSpawnInterval);
    }

    void Update()
    {
        // Augmenter le taux de spawn progressivement
        currentSpawnInterval = Mathf.Clamp(currentSpawnInterval - spawnRateIncreasePerSecond * Time.deltaTime, maxSpawnRate, initialSpawnInterval);
    }

    private void DropRandomPosition()
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
        instantiatedPrefab = Instantiate(dropPrefab, spawnPosition, Quaternion.identity);
        DropItfalls();
    }

    private void DropItfalls()
    {
        // Supprimer les contraintes de gel sur les axes x et y de la nouvelle instance
        Rigidbody2D rb = instantiatedPrefab.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
        else
        {
            Debug.LogWarning("Rigidbody2D non trouvé sur la prefab instanciée.");
        }
    }
}
