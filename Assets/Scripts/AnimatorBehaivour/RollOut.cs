using UnityEngine;

public class RollOut : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetComponent<PlayerState>() != null)
            animator.GetComponent<PlayerState>().OutRoll();
    }
}