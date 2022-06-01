using UnityEngine;

public class PureVessel_Move : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    public float speed = 2.5f;
    PureVessel boss;
    // Transitioning Attacks
    // Light
    public float lightRange;
    // Heavy
    public float heavyRange;
    // Ranged
    public float shootingRange;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<PureVessel>();
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

        // Light
        if (Vector2.Distance(player.position, rb.position) <= lightRange)
        {
            animator.SetTrigger("Light");
        }
        // Heavy
        if (Vector2.Distance(player.position, rb.position) <= heavyRange)
        {
            animator.SetTrigger("Heavy");
        }
        // Ranged
        if (Vector2.Distance(player.position, rb.position) <= shootingRange)
        {
            animator.SetBool("isShooting",true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Light");
        animator.ResetTrigger("Heavy");
        animator.SetBool("isShooting", false);
    }
}
