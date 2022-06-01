using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed;
    Transform player;
    Vector2 target;
    public Rigidbody2D rb;

    public int damage;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(transform.position.x, player.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            // Register damage to the player
            // Destroy the Missile
            DestroyLaser();
        }
    }
    // Detect player
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerStats player = hitInfo.GetComponent<PlayerStats>();
        if (hitInfo.CompareTag("Player"))
        {
            // damage player
            player.TakeDamage(damage);
            DestroyLaser();
        }
    }

    void DestroyLaser()
    {
        Destroy(gameObject);
    }
}
