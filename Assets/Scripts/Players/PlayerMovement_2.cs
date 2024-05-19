using UnityEngine;

public class PlayerMovement_2 : MonoBehaviour
{
    AudioManager audioManager;
    // Variables de mouvement
    public float moveSpeed = 350f;
    public float jumpForce = 7f;

    // Variables d'état
    private bool isJumping;
    public bool isGrounded;

    // Points de vérification au sol
    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    // Rigidbody
    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;

    // Composants d'animation
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    // Variables de gravité
    [SerializeField] private float _fallMultiplier = 2f;
    [SerializeField] private float _lowJumpFallMultiplier = 2f;

    // Variable pour vérifier si le joueur est poussé
    private bool isPushed = false; // Ajout de cette variable
    public bool isMoving;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Méthode appelée à chaque frame
    void Update()
    {
        // Sauter si le joueur est au sol et n'est pas poussé
        if (Input.GetButtonDown("Jump_2") && isGrounded && !isPushed) // Ajouter !isPushed ici
        {
            isJumping = true;
        }
    }

    // Méthode appelée à intervalles réguliers
    void FixedUpdate()
    {
        // Ne pas exécuter le mouvement si le joueur est poussé

        // Vérifier si le joueur est au sol
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);
        if (!isPushed) // Ajouter cette condition
        {
            // Calcul du mouvement horizontal
            float horizontalMovement = Input.GetAxis("Horizontal_2") * moveSpeed * Time.deltaTime;
            MovePlayer(horizontalMovement);
            if (Input.GetAxis("Horizontal_2") > 0.3 || Input.GetAxis("Horizontal_2") < -0.3)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
        }
        animator.SetBool("isMoving", isMoving);

        Jump();
        FallMultiplier();

        // Animation du personnage
        float characterVelocityX = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("SpeedX", characterVelocityX);
        Flip(rb.velocity.x);

    }

    // Gestion de la gravité lors de la chute
    private void FallMultiplier()
    {
        if (rb.velocity.y < 0.1f)
        {
            rb.gravityScale = _fallMultiplier;
        }
        else if (rb.velocity.y > 0.1f && !Input.GetButton("Jump_2"))
        {
            rb.gravityScale = _lowJumpFallMultiplier;
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    // Mouvement horizontal du joueur
    void MovePlayer(float _horizontalMovement)
    {
        // Mouvement horizontal
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    }

    private void Jump()
    {
        // Saut
        if (isJumping == true)
        {
            audioManager.PlaySFX(audioManager.jump);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = false;
        }
    }

    // Flip du sprite du joueur en fonction de sa direction
    void Flip(float _velocityX)
    {
        if (_velocityX > 0.1f)
        {
            spriteRenderer.flipX = true;
        }
        else if (_velocityX < -0.1f)
        {
            spriteRenderer.flipX = false;
        }
    }

    // Méthode pour définir si le joueur est poussé ou non
    public void SetPushed(bool state) // Ajouter cette méthode
    {
        isPushed = state;
        Invoke("StopPushed", 0.15f);
    }
    public void StopPushed() // Ajouter cette méthode
    {
        isPushed = false;

    }
}