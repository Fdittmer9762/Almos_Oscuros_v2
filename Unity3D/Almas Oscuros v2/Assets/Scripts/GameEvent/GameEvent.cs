using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "GameEvent")]
public class GameEvent : ScriptableObject {

	private List<GameEventListener> listners = new List<GameEventListener> ();

	public void Raise(){
		for (int i = listners.Count - 1; i >= 0; i--) {
			listners [i].OnEventRaised ();
		}
	}

	public void RegisterListner(GameEventListener listner){
		listners.Add (listner);
	}

	public void UnregisterListner(GameEventListener listner){
		listners.Remove (listner);
	}

}
