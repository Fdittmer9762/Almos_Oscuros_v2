using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRelease : StateMachineBehaviour
{

    public string InputButton;

    public string TriggerParam;

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetButtonUp(InputButton))
        {
            animator.SetTrigger(TriggerParam);
        }
    }

}
