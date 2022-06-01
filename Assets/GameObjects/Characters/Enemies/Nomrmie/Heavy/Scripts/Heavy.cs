using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heavy : MonoBehaviour
{
    // References
    public Animator animator;

    // Variables
    // Health
    public int maxHealth = 100;
    int currentHealth;

    // Patrol
    bool move = true;
    public float speed;
    public float groundDistance = 1f;
    public float wallDistance = 0.0001f;
    public Transform groundDetection;
    public Transform wallDetection;
    public LayerMask ground;
    public LayerMask wall;
    bool movingRight = true;
    Color rayGColor = Color.green;
    Color rayWColor = Color.red;

    // Attack
    public float stoppingDistance;
    public float attackRange = 1f;
    public int attackDamage = 40;
    public Transform playerDetection;
    public Transform attackPoint;
    public LayerMask player;
    Color raySColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        // Health
        currentHealth = maxHealth;
    }
    void Update()
    {
        // Moving Enemy
        if (move)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

    }

    void FixedUpdate()
    {
        // Creating Raycast
        RaycastHit2D groundinfo = Physics2D.Raycast(groundDetection.position, Vector2.down, groundDistance, ground); // Ground
        Debug.DrawRay(groundDetection.position, Vector2.down * groundDistance, rayGColor);

        RaycastHit2D wallinfo = Physics2D.Raycast(wallDetection.position, wallDetection.right, wallDistance, wall); // Wall
        Debug.DrawRay(wallDetection.position, wallDetection.right * wallDistance, rayWColor);


        // Raycast detection & Patrol
        if (groundinfo == false || wallinfo == true)
        {
            rayGColor = Color.red;
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
        else
        {
            rayGColor = Color.green;
        }

        //Attacking
        //Raycast to detect player
        RaycastHit2D scanPoint = Physics2D.Raycast(playerDetection.position, playerDetection.right, stoppingDistance, player); // Player
        Debug.DrawRay(playerDetection.position, playerDetection.right * stoppingDistance, raySColor);
        //Getting the enemy to stop when the player is detected
        if (scanPoint == true)
        {
            move = false;
            raySColor = Color.green;
            animator.SetBool("Stop", true);
            //Play animation
            animator.SetBool("Attack", true);
        }
        else
        {
            move = true;
            raySColor = Color.red;
            animator.SetBool("Stop", false);
            animator.SetBool("Attack", false);
        }

    }

    // Attacking
    void EnemyAttack()
    {
        // Detect Player
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, player);
        // Damage Player
        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<PlayerStats>().TakeDamage(attackDamage);
        }
    }
    // Visualising Attack Points
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    // Taking Damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //play hurt animation
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Die
    void Die()
    {
        // Die animation
        animator.SetTrigger("Dead");

        // Disable Collider
        GetComponent<Collider2D>().enabled = false;

        // Switch Body Type to Static
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        // Disable Script
        this.enabled = false;
    }
}
