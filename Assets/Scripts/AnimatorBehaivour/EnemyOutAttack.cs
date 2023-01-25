using UnityEngine;

public class EnemyOutAttack : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetComponent<EnemyState>() != null)
            animator.GetComponent<EnemyState>().OutAttack();
    }
}