using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region References and Variables
    #region References
    // Component References
    public CharacterController2D controller;
    public Rigidbody2D rb;
    public Animator animator;
    #endregion

    #region Variables
    // Variables
    #region Movement
    // Move
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    #endregion

    #region Jumping
    // Jump
    bool jump = false;
    //Holding Jump
   public bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public LayerMask whatIsWall;
    private float jumpTimeCounter;
    public float jumpTime;
    bool isJumping;
    #endregion

    #region Wall Movement
    #region Wall Sliding
    // Wall Slide
    public bool isTouchingFront;
    public Transform frontCheck;
    bool wallSliding;
    public float wallSlidingSpeed;
    #endregion

    #region Wall Jumping
    // Wall Jumping
    bool wallJumping;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;
    #endregion
    #endregion

    #region Dashing
    // Dash
    IEnumerator dashCoroutine;
    bool isDashing;
    bool canDash = true;
    float direction = 1;
    float normalGravity;
#endregion
#endregion
#endregion

    void Start()
    {
        #region Setting Gravity components for the Dash
        // Dash
        rb = GetComponent<Rigidbody2D>();
        normalGravity = rb.gravityScale;
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        #region How Move
        // Move
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        #endregion

        #region Everything about jumping
        #region How to Jump
        // Jump
        if (isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            jump = true;
            animator.SetBool("isJumping", true);
            // Play Sound
            FindObjectOfType<Audio_Manager>().Play("Jump");
        }
        #endregion

        #region Holding the jump button for extra height
        // Holding Jump
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (jumpTimeCounter > 0 && isJumping == true)
            {
                jump = true;
                jumpTimeCounter -= Time.deltaTime;
                animator.SetBool("isJumping", true);
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            isJumping = false;
        }
        #endregion
        #endregion

        #region Wall Movement
        #region Wall Sliding
        // Wall Slide
        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatIsWall);
        if (isTouchingFront == true && isGrounded == false && horizontalMove != 0)
        {
            wallSliding = true;
        }
        else
        {
            wallSliding = false;
        }
        #endregion

        #region Wall Jumping
        // Wall Jumping
        if (Input.GetKeyDown(KeyCode.UpArrow) && wallSliding == true)
        {
            wallJumping = true;
            Invoke("SetWallJumpingToFalse", wallJumpTime);
        }
        #endregion
        #endregion

        #region Prepraing the Dash before Coroutine
        // Dash
        if (horizontalMove != 0)
        {
            direction = horizontalMove;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && canDash == true)
        {
            if (dashCoroutine != null)
            {
                StopCoroutine(dashCoroutine);
            }
            dashCoroutine = Dash(.1f, .5f);
            // Play Sound
            FindObjectOfType<Audio_Manager>().Play("Dash");
            animator.SetTrigger("Dash");
            StartCoroutine(dashCoroutine);
        }
        #endregion
    }

    #region stopping the jump animation as we land
    // stopping jump animation on landing
    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
        animator.SetBool("wallHold", false);
        animator.SetBool("wallJump", false);
    }
    #endregion

    #region Function stopping wall Jumping
    // Setting wall Jumping to false
    void SetWallJumpingToFalse()
    {
        wallJumping = false;
    }
    #endregion

    // Used to apply input to our character
    void FixedUpdate()
    {
        #region Moving
        // Move
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        #endregion

        #region Jumping
        // Jump
        jump = false;
        #endregion

        #region Dashing
        // Dash
        if (isDashing)
        {
            rb.AddForce(new Vector2(direction * 0.5f, 0), ForceMode2D.Impulse);
        }
        #endregion

        #region Wall Movement
        #region Wall Sliding
        // Wall Slide
        if (wallSliding)
        {
            animator.SetBool("wallHold", true);
            animator.SetBool("wallJump", false);
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        #endregion

        #region Jumping
        // Wall Jump
        if (wallJumping)
        {
            animator.SetBool("wallHold", false);
            animator.SetBool("wallJump", true);
            rb.velocity = new Vector2(xWallForce * -horizontalMove, yWallForce);
        }
        #endregion
        #endregion
    }

    #region Dash Coroutine
    // Dash
    IEnumerator Dash(float dashDuration, float dashCooldown)
    {
        Vector2 originalVelocity = rb.velocity;
        isDashing = true;
        canDash = false;
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        rb.gravityScale = normalGravity;
        rb.velocity = originalVelocity;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
    #endregion
}
