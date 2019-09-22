using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSound : MonoBehaviour {

	AudioSource audio;
	private bool alreadyPlayed=false;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnCollisionEnter(Collision col){
		if (!alreadyPlayed && col.gameObject.tag != "LaneCollider") {
			audio.Play ();
			alreadyPlayed = true;
		}
	}



}
