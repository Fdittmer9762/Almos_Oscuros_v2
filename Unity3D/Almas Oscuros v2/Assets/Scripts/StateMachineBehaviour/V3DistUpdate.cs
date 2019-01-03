using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V3DistUpdate : StateMachineBehaviour {

	public string FloatParam01, FloatParam02;

	public string SetParam;

	public override void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetFloat(SetParam, Vector3.Distance (Vector3.zero, new Vector3(animator.GetFloat(FloatParam01), 0 ,animator.GetFloat(FloatParam02))));
	}

}
