using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFloatUpdate : StateMachineBehaviour {
    public string AnimParam;
    public float value;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetFloat(AnimParam, value);
    }
}
