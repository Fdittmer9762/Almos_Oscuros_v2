using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncFloatUpdate : StateMachineBehaviour {

	public string AnimParam;
	public float rate;

	public override void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetFloat (AnimParam, animator.GetFloat(AnimParam) + (rate*Time.deltaTime));
	}

}
