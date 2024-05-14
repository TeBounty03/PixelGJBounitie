using UnityEngine;

public class DropSpawner : MonoBehaviour
{
    public GameObject dropPrefab;
    public Camera mainCamera;
    public float spawnInterval =  1f;
    public float waitTime = 10f;
    private GameObject instantiatedPrefab;

    void Start()
    {
        InvokeRepeating("DropRandomPosition", 0f, spawnInterval);
    }

    // private IEnumerator WaitBeforeItFalls()
    // {
    //     yield return new WaitForSeconds(waitTime);
    //     Debug.Log("Attendu 3 secondes. Exécute maintenant le reste du code.");

    //     DropIfalls();

    // }
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
