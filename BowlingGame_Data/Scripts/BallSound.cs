using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour {

	public AudioClip SoundtoPlay1;
	private float speed = 10.0f;
	public AudioSource aud;
	private bool alreadyPlayed=false;
	Rigidbody rb;

	void Start(){
		rb = GetComponent<Rigidbody>();
		aud = GetComponent<AudioSource> ();
	}

		void OnCollisionEnter(Collision col)
		{
		if (col.gameObject.tag == "LaneCollider" && !alreadyPlayed) {
		    	
			AudioSource.PlayClipAtPoint (SoundtoPlay1, transform.position);
		}

		if(col.gameObject.tag == "LaneCollider" && rb.velocity.magnitude >=speed) {
			aud.Play();
		    }
		}

	public void ResetSound(){
		aud.Stop ();
		alreadyPlayed = false;
	}

}
