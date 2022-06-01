using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevitatorHealth : MonoBehaviour
{
    public int maxHealth = 1000;
    int currentHealth;

    public HealthBar healthBar;
    // Spawning elevator
    public GameObject elevator;
    public Transform spawnPoint;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        GetComponent<Animator>().SetTrigger("Dead");
        Invoke("Destroy",2f);
    }
    void Destroy()
    {
        Instantiate(elevator, spawnPoint.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
