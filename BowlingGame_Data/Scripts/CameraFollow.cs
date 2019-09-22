using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


	public GameObject ball;
	private Vector3 offset;
	private bool Isfollowing;
	private  Vector3 StartPos;
	// Use this for initialization
	void Start () {
		Isfollowing = false;
		StartPos = this.transform.position;
		offset = ball.transform.position - this.transform.position;
		
	}

	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Space))
			Isfollowing = true;
		if (Isfollowing && ball.transform.position.z <= -28.0f) 
			this.transform.position = ball.transform.position - offset;
		
	}

	public void ResetCamera(){
		Isfollowing = false;
		this.transform.position = StartPos;
	}
}
