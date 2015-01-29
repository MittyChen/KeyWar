//using UnityEngine;
//using System.Collections;
//
//public class JoySticsControl : MonoBehaviour {
//	public GameObject player = null;
//	tk2dSpriteAnimator tkanim;
//	public Vector3 jumpVelocity;
//	public Vector3 runVelocity;
//	private bool longPress = false;
//	// Use this for initialization
//	void Start () {
//		tkanim =  player.GetComponent<tk2dSpriteAnimator>();
//	}
//	
//	// Update is called once per frame
//	void Update () {
//
//
//
//	}
//
//	public void logButton(){
//		Debug.Log ("this is the button");
//	}
////	TouchPhase.Stationary
//	public void touchLeft(){
//
//		if (player.GetComponent<PlayerController>().playerState == 1 ) {
//						player.rigidbody.velocity = new Vector3 (-1 * runVelocity.x, player.rigidbody.velocity.y, 0);
//						tkanim.Play ("walkright");
//				}
//		longPress = true;
//	}
//
//	public void touchRight(){
//		if (player.GetComponent<PlayerController> ().playerState == 1) {
//						player.rigidbody.velocity = new Vector3 (runVelocity.x, player.rigidbody.velocity.y, 0);
//						;
//						tkanim.Play ("leftwalk");
//				}
//	}
//	public void touchUp(){
//		if (player.GetComponent<PlayerController> ().playerState == 1) {
//						if (tkanim.CurrentClip.name == "leftwalk") {
//								player.rigidbody.velocity = new Vector3 (runVelocity.x, jumpVelocity.y, 0);
//								;
//						} else if (tkanim.CurrentClip.name == "walkright") {
//								player.rigidbody.velocity = new Vector3 (-1 * runVelocity.x, jumpVelocity.y, 0);
//								;
//						} else {
//			
//								player.rigidbody.velocity = new Vector3 (jumpVelocity.x, jumpVelocity.y, 0);
//								;
//						}
//				}
//	}
//	public void touchDown(){
////		if (player.GetComponent<PlayerController> ().playerState == 1) {
////						tkanim.Play ("pale");
////				}
//	}
//
//
//
//}






using UnityEngine;
using System.Collections;

public class JoySticsControl : MonoBehaviour {
	public GameObject player;
	tk2dSpriteAnimator tkanim;
	public Vector3 jumpVelocity;
	public Vector3 runVelocity;
	private bool longPress = false;
	private Vector3 currentVelocity = Vector3.zero  ;

	public GameObject mask;

	// Use this for initialization
	void Start () {
		tkanim =  player.GetComponent<tk2dSpriteAnimator>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(longPress){
			player.transform.Translate(- currentVelocity *  Time.deltaTime);
		} 
	}
	
	public void logButton(){
		Debug.Log ("this is the button");
	}
	//	TouchPhase.Stationary
	public void touchLeft(){
		
		if (player.GetComponent<PlayerController>().playerState == 1 ) {
			currentVelocity = new Vector3 (-1 * runVelocity.x, player.rigidbody.velocity.y, 0);
			tkanim.Play ("walkright");
			longPress = true;
		}
		 
	}
	
	public void touchRight(){
		if (player.GetComponent<PlayerController> ().playerState == 1) {
			currentVelocity = new Vector3 (runVelocity.x, player.rigidbody.velocity.y, 0);
			tkanim.Play ("leftwalk");
			longPress = true;
		}

	}
	public void touchUp(){
		if (player.GetComponent<PlayerController> ().playerState == 1) {
			if (tkanim.CurrentClip.name == "leftwalk") {
				currentVelocity = new Vector3 (runVelocity.x, jumpVelocity.y, 0);
			} else if (tkanim.CurrentClip.name == "walkright") {
				currentVelocity = new Vector3 (-1 * runVelocity.x, jumpVelocity.y, 0);
			} else {
				
				currentVelocity = new Vector3 (jumpVelocity.x, jumpVelocity.y, 0);
			}
			tkanim.Play ("fly");
			player.rigidbody.velocity = currentVelocity;
		}
	}
	public void touchDown(){
		//		if (player.GetComponent<PlayerController> ().playerState == 1) {
		//						tkanim.Play ("pale");
		//				}
	}
	public void longTouchEnd(){
		if (player.GetComponent<PlayerController> ().playerState == 1) {
			longPress = false;
			tkanim.Play ("stay");
		}
	}
	public void longPressUPEnd(){
		tkanim.Play ("stay");
	}


	public void showPauseBox()
	{
		mask.SetActive (true);
		GameObject.FindGameObjectWithTag ("pause").GetComponent<UIPlayTween> ().playDirection = AnimationOrTween.Direction.Forward;
		GameObject.FindGameObjectWithTag ("pause").GetComponent<UIPlayTween>().Play(true);
	}

	public void closePauseBox()
	{
		mask.SetActive (false);
		GameObject.FindGameObjectWithTag ("pause").GetComponent<UIPlayTween> ().playDirection = AnimationOrTween.Direction.Reverse;
		GameObject.FindGameObjectWithTag ("pause").GetComponent<UIPlayTween>().Play(true);
	}





}
