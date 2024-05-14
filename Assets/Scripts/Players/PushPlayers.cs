using UnityEngine;

public class PushPlayers : MonoBehaviour
{
    public float pushForce = 1f;
    private bool isPushing = false;

    void Update()
    {
        // Si vous appuyez sur une touche spécifique (par exemple la barre d'espace), commencez à pousser les autres joueurs
        if (Input.GetKeyDown(KeyCode.Space) && !isPushing)
        {
            isPushing = true;
            PushOtherPlayers();
            Invoke("StopPushing", 5f); // Appelle la méthode StopPushing après 5 secondes
        }
    }

    private void PushOtherPlayers()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, GetComponent<CircleCollider2D>().radius);

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
                    PlayerMovement_2 playerMovement = collider.GetComponent<PlayerMovement_2>();
                    if (playerMovement != null)
                    {
                        playerMovement.SetPushed(true);
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