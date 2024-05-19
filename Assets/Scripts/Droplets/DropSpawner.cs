using System.Collections;
using UnityEngine;

public class DropSpawner : MonoBehaviour
{
    public GameObject dropPrefab;
    private GameObject instantiatedDropPrefab;
    public Camera mainCamera;
    private float cameraHeight;
    private float cameraWidth;
     public float initialDropSpawnRate = 1f; // Taux initial de création de gouttes (en secondes)
    public float dropSpawnRateIncrease = 0.1f; // Augmentation du taux de création de gouttes par seconde
    public float maxSpawnRate = 0.5f; // Taux maximal de création de gouttes

    private float nextDropSpawnTime; // Temps avant la prochaine création de gouttes
    private float currentDropSpawnRate;


    void Start()
    {
        currentDropSpawnRate = initialDropSpawnRate;
        nextDropSpawnTime = Time.time + currentDropSpawnRate;
        if (mainCamera == null)
        {
            mainCamera = Camera.main; // Assigner la caméra principale si non assignée
        }
        //currentSpawnInterval = interval;
        //InvokeRepeating("DropDroplet", 0f, currentSpawnInterval);
        //StartCoroutine();
    }

    void Update()
    {
        if (Time.time > nextDropSpawnTime)
        {
            StartCoroutine(DropDroplets());
            nextDropSpawnTime = Time.time + currentDropSpawnRate;
            currentDropSpawnRate = Mathf.Max(currentDropSpawnRate - dropSpawnRateIncrease, maxSpawnRate);
        }
    }

    private void DropRandomPosition(out Vector3 spawnPosition)
    {
        // Récupérer la taille de la caméra pour calculer la position en haut
        cameraHeight = 2f * mainCamera.orthographicSize;
        cameraWidth = cameraHeight * mainCamera.aspect;

        // Calculer une position aléatoire en haut de la caméra
        float randomX = Random.Range(-cameraWidth / 2f, cameraWidth / 2f);
        spawnPosition = new Vector3(
            mainCamera.transform.position.x + randomX,
            mainCamera.transform.position.y + (cameraHeight / 2f),
            0f
        );
    }

    private IEnumerator DropDroplets()
    {
        for (int i = 0; i < 3; i++)
        {
            DropRandomPosition(out Vector3 spawnPosition);
    ;       // Instancier le prefab de goutte à la position aléatoire
            instantiatedDropPrefab = Instantiate(dropPrefab, spawnPosition, Quaternion.identity);
            // Supprimer les contraintes de gel sur les axes x et y de la nouvelle instance
            Rigidbody2D rb = instantiatedDropPrefab.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.constraints = RigidbodyConstraints2D.None;
            }
            else
            {
                Debug.LogWarning("Rigidbody2D non trouvé sur la prefab instanciée.");
            }
            yield return new WaitForSeconds(0.5f);
        }
       
    }
}
