using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncFloatStart : StateMachineBehaviour
{
    public string AnimParam;
    public float rate;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetFloat(AnimParam, animator.GetFloat(AnimParam) + rate);
    }
}
