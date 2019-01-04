using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBoolExit : StateMachineBehaviour
{

    public string AnimParam;
    public bool boolSet = true;

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(AnimParam, boolSet);
    }

}
