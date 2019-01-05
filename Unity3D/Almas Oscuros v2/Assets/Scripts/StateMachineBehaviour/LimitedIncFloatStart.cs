using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitedIncFloatStart : StateMachineBehaviour
{

    public string AnimParam;

    public float val = 0f;

    public bool max = true, min = false;

    public float upperLimit, lowerLimit;

    [Range(0f, 1f)]
    public float overshoot;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.SetFloat(AnimParam, animator.GetFloat(AnimParam) + val);

        float stVal = animator.GetFloat(AnimParam);

        if (max && min) {
            if (stVal > upperLimit || stVal < lowerLimit) {
                Debug.Log((overshoot - lowerLimit) / (lowerLimit - upperLimit));
                animator.SetFloat(AnimParam, Mathf.Lerp(upperLimit, lowerLimit, (overshoot - lowerLimit)/(lowerLimit - upperLimit)));
            }
        }

        else if (max && stVal > upperLimit) {
            animator.SetFloat(AnimParam, upperLimit);
        }

        else if (min && stVal < lowerLimit) {
            animator.SetFloat(AnimParam, lowerLimit);
        }

    }

}
