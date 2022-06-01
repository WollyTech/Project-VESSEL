using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 100;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        // Play sound
        FindObjectOfType<Audio_Manager>().Play("Shoot");
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Heavy
        Heavy heavy = hitInfo.GetComponent<Heavy>();
        if (heavy != null)
        {
            heavy.TakeDamage(damage);
            FindObjectOfType<Audio_Manager>().Play("EnemyHit");

        }
        // Tank
        Tank_Health tankBoss = hitInfo.GetComponent<Tank_Health>();
        if (tankBoss != null)
        {
            tankBoss.TakeDamage(damage);
            FindObjectOfType<Audio_Manager>().Play("EnemyHit");
        }
        // Pure Vessel
        PureVessel_Health purevesselBoss = hitInfo.GetComponent<PureVessel_Health>();
        if (purevesselBoss != null)
        {
            purevesselBoss.TakeDamage(damage);
            FindObjectOfType<Audio_Manager>().Play("EnemyHit");
        }
        Destroy(gameObject);
    }
}
