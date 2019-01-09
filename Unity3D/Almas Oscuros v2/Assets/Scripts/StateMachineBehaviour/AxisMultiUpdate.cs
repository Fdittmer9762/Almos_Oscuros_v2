using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisMultiUpdate : StateMachineBehaviour
{

    public string inputString;

    public string AnimParam;

    public float mult;

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetFloat(AnimParam, Input.GetAxis(inputString) * mult);
    }

}
