using UnityEngine;

public class PlayerOutAttack : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetComponent<PlayerState>() != null)
            animator.GetComponent<PlayerState>().InAttack();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetComponent<PlayerState>() != null)
            animator.GetComponent<PlayerState>().OutAttack();
    }
}