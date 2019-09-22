using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	private float distToRaise = 10f;
	private float standingThreshold=2.4f;
	private Rigidbody rigidBody;
	public float tilt;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}
	

	public bool IsStanding(){
		Vector3 rotation = transform.position;
		
		tilt = rotation.y;
	
		if (tilt > standingThreshold ) {
			return true;
		} else {
			
			return false;
		}
	}


	public void RaiseIfStanding () {
		if (IsStanding()) {
			rigidBody.useGravity = false;
			transform.Translate (new Vector3 (0, distToRaise, 0), Space.World);
	}
	}

	public void Lower () {
		transform.Translate (new Vector3 (0, -distToRaise, 0), Space.World);
		rigidBody.useGravity = true;
	}





}
