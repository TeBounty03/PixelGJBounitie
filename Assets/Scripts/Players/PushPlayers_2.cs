using UnityEngine;

public class PushPlayers_2 : MonoBehaviour
{
    AudioManager audioManager;
    public float pushForce = 8f;
    private bool isPushing = false;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        // Si vous appuyez sur une touche spécifique (par exemple la barre d'espace), commencez à pousser les autres joueurs
        if (Input.GetKeyDown(KeyCode.S) && !isPushing)
        {
            isPushing = true;
            PushOtherPlayers();
            Invoke("StopPushing", 3f); // Appelle la méthode StopPushing après 5 secondes
        }
    }

    private void PushOtherPlayers()
    {
        audioManager.PlaySFX(audioManager.bump);
        // Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, GetComponent<CircleCollider2D>());
        // Obtenir le composant BoxCollider2D attaché à l'objet
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();

        if (boxCollider != null)
        {
            // La position centrale du BoxCollider2D
            Vector2 center = (Vector2)transform.position + boxCollider.offset;

            // La taille du BoxCollider2D
            Vector2 size = boxCollider.size;

            // L'angle de rotation du BoxCollider2D (en degrés)
            float angle = transform.eulerAngles.z;

            // Obtenir tous les Collider2D dans la zone du BoxCollider2D
            Collider2D[] colliders = Physics2D.OverlapBoxAll(center, size, angle);

            foreach (Collider2D collider in colliders)
            {
                // Vérifiez si le collider est un joueur autre que le joueur 1
                if (collider.CompareTag("Player") && collider.gameObject != gameObject)
                {
                    // Calculez la direction du push
                    Vector2 pushDirection = (collider.transform.position - transform.position).normalized;

                    // Appliquez la force de poussée
                    Rigidbody2D otherRigidbody = collider.GetComponent<Rigidbody2D>();
                    if (otherRigidbody != null)
                    {
                        otherRigidbody.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);

                        // Appeler la méthode SetPushed du joueur
                        PlayerMovement_1 playerMovement = collider.GetComponent<PlayerMovement_1>();
                        if (playerMovement != null)
                        {
                            playerMovement.SetPushed(true);
                        }
                    }
                }
            }
        }
    }

    private void StopPushing()
    {
        isPushing = false;
    }


}