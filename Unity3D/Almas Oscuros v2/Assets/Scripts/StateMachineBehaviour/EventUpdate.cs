using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventUpdate : StateMachineBehaviour {

	public GameEvent Event;

	public override void OnStateUpdate (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Event.Raise ();
	}

}
