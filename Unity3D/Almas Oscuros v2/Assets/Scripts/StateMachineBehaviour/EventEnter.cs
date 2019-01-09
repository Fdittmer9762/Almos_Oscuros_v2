using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventEnter : StateMachineBehaviour {

	public GameEvent Event;

	public override void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Event.Raise ();
	}

}
