using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncFloatToVal : StateMachineBehaviour {

    public string AnimParam;

    public float rate, finalValue;

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetFloat(AnimParam) < finalValue)
        {
            animator.SetFloat(AnimParam, animator.GetFloat(AnimParam) + (rate * Time.deltaTime));
        }
        if (animator.GetFloat(AnimParam) > finalValue)
        {
            animator.SetFloat(AnimParam, finalValue);
        }
    }

}
