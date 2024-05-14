using UnityEngine;

public class PlayerMovement_2 : MonoBehaviour
{
    public float moveSpeed = 350f;
    public float jumpForce = 7f;

    private bool isJumping;
    public bool isGrounded;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;

    public Animator animator;
    public SpriteRenderer spriteRenderer;
    [SerializeField] private float _fallMultiplier = 2f;
    [SerializeField] private float _lowJumpFallMultiplier = 2f;


    void Update()
    {
        //No double jump
        if (Input.GetButtonDown("Jump_2") && isGrounded)
        {
            isJumping = true;
        }

    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        float horizontalMovement = Input.GetAxis("Horizontal_2") * moveSpeed * Time.deltaTime;
        MovePlayer(horizontalMovement);

        //Change gravity when falling
        FallMultiplier();

        //Animation
        float characterVelocityX = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("SpeedX", characterVelocityX);
        Flip(rb.velocity.x);
    }

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

    void MovePlayer(float _horizontalMovement)
    {
        //Horizontal Movement
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        //Jump
        if (isJumping == true)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = false;
        }
    }

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
}