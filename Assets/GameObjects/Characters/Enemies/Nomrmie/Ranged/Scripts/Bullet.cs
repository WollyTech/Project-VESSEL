using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector2 target;

    public int damage;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2 (player.position.x, player.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            // Register damage to the player
            // Destroy the bullet
            DestroyBullet();
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerStats player = hitInfo.GetComponent<PlayerStats>();
        if (hitInfo.CompareTag("Player"))
        {
            player.TakeDamage(damage);
            DestroyBullet();
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
