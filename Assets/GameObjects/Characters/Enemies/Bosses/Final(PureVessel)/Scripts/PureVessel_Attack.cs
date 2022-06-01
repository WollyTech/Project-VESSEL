using UnityEngine;

public class PureVessel_Attack : MonoBehaviour
{
    public LayerMask playerLayer;
    // Light
    public Transform lightAttackPoint;
    public float lightAttackRange;
    // Heavy
    public Transform heavyAttackPoint;
    public float heavyAttackRange;
    // Shooting
    public GameObject bullet;
    public Transform firePoint;
    float timeBtwShots;
    public float startTimeBtwShots;
    // Damage
    readonly int attackDamage = 100;

    void LightA()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(lightAttackPoint.position, lightAttackRange, playerLayer);
        // Damage Player
        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<PlayerStats>().TakeDamage(attackDamage);
        }
    }

    void HeavyA()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(heavyAttackPoint.position, heavyAttackRange, playerLayer);
        // Damage Player
        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<PlayerStats>().TakeDamage(attackDamage);
        }
    }
    // Visualising Attack Points
    void OnDrawGizmosSelected()
    {
        // Light
        if (lightAttackPoint == null)
            return;
        Gizmos.DrawWireSphere(lightAttackPoint.position, lightAttackRange);
        // Heavy
        if (heavyAttackPoint == null)
            return;
        Gizmos.DrawWireSphere(heavyAttackPoint.position, heavyAttackRange);
    }

    void Shooting()
    {
        // Shooting rate
        if (timeBtwShots <= 0)
        {
            // Shoot bullet
            Instantiate(bullet, firePoint.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.fixedDeltaTime;
        }
    }
}
