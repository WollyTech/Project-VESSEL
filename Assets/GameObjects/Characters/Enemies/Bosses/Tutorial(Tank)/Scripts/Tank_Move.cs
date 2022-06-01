using UnityEngine;

public class Tank_Move : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    public float speed = 2.5f;
    Tank boss;
    // Missile
    public float shootRange;
    // Shield
    public float shieldRange;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Tank>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Find Player every frame
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Orient towards player
        boss.LookAtPlayer();

        // Move
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        // Laser Shield
        if (Vector2.Distance(player.position, rb.position) <= shieldRange)
        {
            animator.SetTrigger("Attack");
        }

        // Missile
        if (Vector2.Distance(player.position, rb.position) <= shootRange)
        {
            animator.SetBool("Shoot", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.SetBool("Shoot", false);
    }
}