using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultFloatEnter : StateMachineBehaviour {

	public string AnimParam;

	public float multiplyer;

	public override void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetFloat (AnimParam, animator.GetFloat (AnimParam) * multiplyer);
	}

}
