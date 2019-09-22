using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

	private float distanceFromCamera;
	private float sensitivity=50;
	private bool timeToFire,MovementIsOff;
	private Vector3 StartPosition;
	private float StartTime;
	private Vector3 FinalPosition;
	private float FinalTime;
	private Vector3 ballStartPos;
	private Rigidbody rb;

	void Start(){
		distanceFromCamera = Vector3.Distance (transform.position, Camera.main.transform.position);
		rb = GetComponent<Rigidbody>();
		timeToFire = false;
		MovementIsOff = false;
		ballStartPos = transform.position;

	}


	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {
			timeToFire = true;
		}
	}

	public void  Reset(){
		transform.position = ballStartPos;
		transform.rotation = Quaternion.identity;
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		rb.useGravity = false;
		timeToFire = false;
		MovementIsOff = false;
		rb.freezeRotation = true;

	}

	//1st movement-choose position to shoot
	void OnMouseDrag(){
		if (!timeToFire && !MovementIsOff) {
			rb.freezeRotation = true;
			Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distanceFromCamera);
			Vector3 objPosition = Camera.main.ScreenToWorldPoint (mousePosition);
			rb.velocity = (objPosition - transform.position) * 10;
		}
	}

	void OnMouseDown(){
		if (timeToFire && !MovementIsOff) {
			StartPosition = Input.mousePosition;
			StartTime=Time.time;
		}

	}
	void OnMouseUp(){

		float distanceX;
		float distanceY;
		float calculatedTime;

		if (!timeToFire && !MovementIsOff) {
			rb.velocity = Vector3.zero;
		}
		if (timeToFire && !MovementIsOff) {

			rb.useGravity=true;
			rb.freezeRotation = false;

			FinalPosition = Input.mousePosition;
			FinalTime=Time.time;
			calculatedTime=FinalTime-StartTime;
			distanceX = (FinalPosition.x-StartPosition.x)*Time.deltaTime*calculatedTime*sensitivity;
			distanceY = FinalPosition.y-StartPosition.y*Time.deltaTime*calculatedTime;

			Vector3 newVelocity= new Vector3(distanceX,0f,distanceY);
			rb.AddForce(newVelocity,ForceMode.Impulse);
			MovementIsOff=true;
		}
	}
}
