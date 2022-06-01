using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public static PlayerCombat instance;
    // Reference Components
    public Animator animator;
    public Transform lightAttackPoint;
    public Transform heavyAttackPoint;
    public Transform firePoint;
    public GameObject bullet;

    // VARIABLES
    // General
    public float attackRate = 2f;
    public int attackDamage = 100;
    float nextAttackTime = 0f;
    // Light
    public float lightAttackRange = 0.5f;
    public LayerMask rangedEnemyLayer;
    // Heavy
    public float heavyAttackRange = 1f;
    public LayerMask lightEnemyLayer;
    // Bosses
    public LayerMask levitatorLayer;
    public LayerMask pureVesselLayer;


    void Awake()
    {
        instance = this;
    }


    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            // Light
            if (Input.GetKeyDown(KeyCode.Z))
            {
                // Play Attack Animation
                animator.SetTrigger("lightAttack");
                // Play Sound
                FindObjectOfType<Audio_Manager>().Play("SwordSwing");
                nextAttackTime = Time.time + 1f / attackRate;
            }
            // Heavy
            if (Input.GetKeyDown(KeyCode.X))
            {
                // Play Attack animation
                animator.SetTrigger("heavyAttack");
                // Play Sound
                FindObjectOfType<Audio_Manager>().Play("AxeSwing");
                nextAttackTime = Time.time + 1f / attackRate;
            }
            // Ranged
            if (Input.GetKeyDown(KeyCode.C))
            {
                // Play Attack animation
                animator.SetTrigger("rangedAttack");
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    // LIGHT ATTACK
    void AttackLight()
    {
        // Detect Enemies
        Collider2D[] hitRangedEnemies = Physics2D.OverlapCircleAll(lightAttackPoint.position, lightAttackRange, rangedEnemyLayer);
        // Damage Ranged Enemies
        foreach(Collider2D enemy in hitRangedEnemies)
        {
            enemy.GetComponent<Ranged>().TakeDamage(attackDamage);
            FindObjectOfType<Audio_Manager>().Play("EnemyHit");
        }
        // Detect Levitator
        Collider2D[] hitLevitator = Physics2D.OverlapCircleAll(lightAttackPoint.position, lightAttackRange, levitatorLayer);
        // Damage Levitator
        foreach (Collider2D enemy in hitLevitator)
        {
            enemy.GetComponent<LevitatorHealth>().TakeDamage(attackDamage);
            FindObjectOfType<Audio_Manager>().Play("EnemyHit");
        }
        // Detect Pure Vessel
        Collider2D[] hitPureVessel = Physics2D.OverlapCircleAll(lightAttackPoint.position, lightAttackRange, pureVesselLayer);
        // Damage Pure Vessel
        foreach (Collider2D enemy in hitPureVessel)
        {
            enemy.GetComponent<PureVessel_Health>().TakeDamage(attackDamage);
            FindObjectOfType<Audio_Manager>().Play("EnemyHit");
        }
    }

    // HEAVY ATTACK
    void AttackHeavy()
    {
        // Detect Light enemies
        Collider2D[] hitLightEnemies = Physics2D.OverlapCircleAll(heavyAttackPoint.position, heavyAttackRange, lightEnemyLayer);
        // Damage Light enemies
        foreach (Collider2D enemy in hitLightEnemies)
        {
            enemy.GetComponent<LightE>().TakeDamage(attackDamage);
            FindObjectOfType<Audio_Manager>().Play("EnemyHit");
        }
        // Detect Pure Vessel
        Collider2D[] hitPureVessel = Physics2D.OverlapCircleAll(heavyAttackPoint.position, heavyAttackRange, pureVesselLayer);
        // Damage Pure Vessel
        foreach (Collider2D enemy in hitPureVessel)
        {
            enemy.GetComponent<PureVessel_Health>().TakeDamage(attackDamage);
            FindObjectOfType<Audio_Manager>().Play("EnemyHit");
        }
    }

    // RANGED
    void AttackRange()
    {
        // Shoot bullet
        Instantiate (bullet, firePoint.position, firePoint.rotation);
    }

    // Visualising Attack Points
    void OnDrawGizmosSelected()
    {
        // Light
        if (lightAttackPoint == null)
            return;
        Gizmos.DrawWireSphere(lightAttackPoint.position, lightAttackRange);
        //Heavy
        if (heavyAttackPoint == null)
            return;
        Gizmos.DrawWireSphere(heavyAttackPoint.position, heavyAttackRange);
    }

}
