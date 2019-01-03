using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFloatEnter : StateMachineBehaviour {

	public string AnimParam;

	public float value = 0f;

	public override void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetFloat (AnimParam, value);
	}

}
