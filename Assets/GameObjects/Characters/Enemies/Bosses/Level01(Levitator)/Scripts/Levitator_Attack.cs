using UnityEngine;

public class Levitator_Attack : MonoBehaviour
{
    // Attacking
    public LayerMask playerLayer;
    // Laser
    public GameObject laser;
    public Transform laserCanon;
    float timeBtwShots;
    public float startTimeBtwShots;
    // Sword 
    public Transform attackPoint;
    public float attackRange;
    readonly int attackDamage = 100;
    // Fire Blaster
    public Transform firePoint;
    public float fireRange;

    public void Sword()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
        // Damage Player
        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<PlayerStats>().TakeDamage(attackDamage);
        }
    }
    public void GroundHeat()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(firePoint.position, fireRange, playerLayer);
        // Damage Player
        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<PlayerStats>().TakeDamage(attackDamage);
        }
    }
    // Visualising Attack Points
    void OnDrawGizmosSelected()
    {
        // Sword
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        // Ground Heat
        if (firePoint == null)
            return;
        Gizmos.DrawWireSphere(firePoint.position, fireRange);
    }

    public void Shoot()
    {
        // Shooting rate
        if (timeBtwShots <= 0)
        {
            // Shoot bullet
            Instantiate(laser, laserCanon.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.fixedDeltaTime;
        }
    }
}
