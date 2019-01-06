using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBool : StateMachineBehaviour
{

    public string AnimParam, inputButton;

    public bool startState, pressState;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(AnimParam, startState);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetButtonDown(inputButton)) {
            animator.SetBool(AnimParam, pressState);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(AnimParam, startState);
    }

}
