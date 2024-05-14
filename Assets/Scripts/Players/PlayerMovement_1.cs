using UnityEngine;

public class PlayerMovement_1 : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

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

        if (Input.GetButtonDown("Jump_1") && isGrounded)
        {
            isJumping = true;
        }

    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        float horizontalMovement = Input.GetAxis("Horizontal_1") * moveSpeed * Time.deltaTime;

        MovePlayer(horizontalMovement);

        float characterVelocityX = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("SpeedX", characterVelocityX);

        //Animations de saut
        // animator.SetFloat("SpeedY", rb.velocity.y);
        // animator.SetBool("isGrounded", isGrounded);

        Flip(rb.velocity.x);
        FallMultiplier();
    }

    private void FallMultiplier()
    {

        if (rb.velocity.y < 0.1f)
        {
            rb.gravityScale = _fallMultiplier;
        }
        else if (rb.velocity.y > 0.1f && !Input.GetButton("Jump_1"))
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
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        //Jump
        if (isJumping == true)
        {
            // rb.AddForce(new Vector2(0f, jumpForce));
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
