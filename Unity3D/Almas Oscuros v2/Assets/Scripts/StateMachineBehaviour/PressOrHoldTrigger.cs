using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressOrHoldTrigger : StateMachineBehaviour
{

    public string inputButton, pressTrigger, holdTrigger;

    public float holdTime;

    private float timer;

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetButton(inputButton)) {
            timer += Time.deltaTime;
            if (timer > holdTime) {
                animator.SetTrigger(holdTrigger);
                timer = 0f;
            }
        }
        else if (Input.GetButtonUp(inputButton) && timer < holdTime) {
            animator.SetTrigger(pressTrigger);
            timer = 0f;
        }
    }

}
