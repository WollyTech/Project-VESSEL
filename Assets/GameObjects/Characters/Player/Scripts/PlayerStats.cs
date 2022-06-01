using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //Variables
    public float maxHealth;
    private float currentHealth;
    public Animator animator;
    public PlayerMovement move;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Taking Damage
    public void TakeDamage (int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Automatically Killing player with the Level Lasers (NOT THE BOSS!!!!!)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            Die();
        }
    }

    void Die()
    {
        // Play death sound
        FindObjectOfType<Audio_Manager>().Play("PlayerDeath");
        // play death animation
        animator.SetTrigger("Dead");
        // Disable Collider
        GetComponent<Collider2D>().enabled = false;
        // Game Over
        move.enabled = false;

        FindObjectOfType<GameManager>().GameOver();
        // Disable script
        this.enabled = false;
    }
}
