using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private BallControl ball;
	private CameraFollow cam;
	private BallSound ballsound;
	private PinSetter pinsetter;
	private PinCounter pincounter;
	private Swiper swip;
	private ScoreDisplay scoreDisplay;



	private List <int> rolls = new List<int> ();
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<BallControl>();
		cam= GameObject.FindObjectOfType<CameraFollow>();
		ballsound=GameObject.FindObjectOfType<BallSound>();
		pinsetter = GameObject.FindObjectOfType<PinSetter> ();
		pincounter = GameObject.FindObjectOfType<PinCounter> ();
		swip=GameObject.FindObjectOfType<Swiper> ();
		scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay> ();

	}


	IEnumerator WaitAndReset(){
		yield return new WaitForSeconds (5);
		pinsetter.RenewPins ();
		pincounter.Reset();
	}

	IEnumerator WaitAndLower(){
		yield return new WaitForSeconds (5);
		pinsetter.LowerPins(); 
	}

	IEnumerator WaitAndSwipe(){
		yield return new WaitForSeconds (2);
		swip.Swipe (); 
		StartCoroutine ("WaitAndLower");
	}

	public void Bowl(int pinFall){
		ballsound.ResetSound ();
		ball.Reset();
		cam.ResetCamera ();
		rolls.Add (pinFall);
		NextAction(rolls);

		scoreDisplay.FillRolls (rolls);
		scoreDisplay.FillFrames (ScoreMaster.ScoreCumulative(rolls));

	}


	void ActionReset(){
		swip.Swipe ();
		StartCoroutine ("WaitAndReset");
	}

	void ActionTidy(){
		pinsetter.RaisePins(); 
		StartCoroutine ("WaitAndSwipe");
	}


	void ActionEndGame(){
		Debug.Log ("End Game!");
	}

	void NextAction(List<int> rolls){
		int i = rolls.Count - 1;

			if (i == 20) {
				ActionEndGame ();
			} else if (i == 19) {
				if (rolls [18] + rolls [19] >= 10) {	// Roll 21 awarded
					ActionReset ();	
				} else {
					ActionEndGame ();
				}
			} else {
			if(i % 2 != 0){

					ActionReset ();

			}
					if(i % 2 == 0){
						if(rolls[i]==10){
					rolls.Add (15); // Insert virtual 0 after strike

					ActionReset ();
					}
				else{
					ActionTidy ();
				}
				}
			}
		}





}
