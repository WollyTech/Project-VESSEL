using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Attack : MonoBehaviour
{
    // Attacking
    public LayerMask playerLayer;
    // Missile
    public GameObject missile;
    public Transform canon;
    float timeBtwShots;
    public float startTimeBtwShots;
    // Laser Shield
    public Transform attackPoint;
    public float attackRange;
    readonly int attackDamage = 100;

    public void LaserShield()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
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

    public void Shoot()
    {
        // Shooting rate
        if (timeBtwShots <= 0)
        {
            // Shoot bullet
            Instantiate(missile, canon.position, Quaternion.identity); 
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.fixedDeltaTime;
        }     
    }
}
