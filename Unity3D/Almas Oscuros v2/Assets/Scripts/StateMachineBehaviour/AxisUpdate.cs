using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisUpdate : StateMachineBehaviour {

	public string inputString;

	public string AnimParam;

	public override void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetFloat (AnimParam, Input.GetAxis (inputString));
	}

}
