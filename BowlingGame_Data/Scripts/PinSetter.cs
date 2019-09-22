using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSetter : MonoBehaviour {

	public GameObject pinSet;
	private BallSound ballsound;


	// Use this for initialization
	void Start () {
		ballsound=GameObject.FindObjectOfType<BallSound>();
	
	}
	
	// Update is called once per frame

	void OnTriggerExit (Collider collider) {
		if (collider.gameObject.name == "Ball") {
			ballsound.ResetSound ();
		}
	}

	public void RaisePins () {
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			pin.RaiseIfStanding();
		}
	}

	public void LowerPins () {
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			pin.Lower();
		}
	}

	public void RenewPins () {
		GameObject newPins = Instantiate (pinSet);
	}

}
