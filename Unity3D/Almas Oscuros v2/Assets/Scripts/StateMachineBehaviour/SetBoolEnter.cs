using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBoolEnter : StateMachineBehaviour {

	public string AnimParam;
	public bool boolSet = true;

	public override void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetBool (AnimParam, boolSet);
	}

}
