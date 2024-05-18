using UnityEngine;
using System.Collections;

public class Droplet_Splash : MonoBehaviour
{

    public Rigidbody2D rb;
    public Animator animator;
    private bool splash;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.transform.GetComponent<PlayerHealth_1>() != null)
            {
                PlayerHealth_1 playerHealth = collision.transform.GetComponent<PlayerHealth_1>();
                playerHealth.TakeDamage(1);
                Destroy();
            }
            else if (collision.transform.GetComponent<PlayerHealth_2>() != null)
            {
                PlayerHealth_2 playerHealth = collision.transform.GetComponent<PlayerHealth_2>();
                playerHealth.TakeDamage(1);
                Destroy();
            }

        }

        if (collision.CompareTag("Ground"))
        {
            Destroy();
        }
    }

    private void Destroy()
    {
        if (rb != null)
        {
            // Geler la position Y
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        else
        {
            Debug.LogError("Aucun Rigidbody trouvé sur ce GameObject. Veuillez ajouter un Rigidbody.");
        }
        splash = true;
        // Destroy(transform.gameObject);
        StartCoroutine(DestroyAfterDelayCoroutine());
    }

    // Coroutine qui attend une seconde avant de détruire l'objet
    private IEnumerator DestroyAfterDelayCoroutine()
    {
        // Attendre 1 seconde
        yield return new WaitForSeconds(0.4f);

        // Détruire l'objet
        Destroy(this.gameObject);
    }

    void FixedUpdate()
    {
        animator.SetBool("Splash", splash);
    }

}
