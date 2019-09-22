using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroypins : MonoBehaviour {

	private BallSound bsound;

	void Start(){
		bsound=GameObject.FindObjectOfType<BallSound>();

	}


	// Use this for initialization
	void OnTriggerEnter (Collider collider) {
		GameObject thingLeft = collider.gameObject;

		if (thingLeft.gameObject.name == "Ball") {
			bsound.ResetSound();
		}

		if (thingLeft.GetComponent<Pin> ()){
			Destroy (thingLeft);

		}
	}
}
