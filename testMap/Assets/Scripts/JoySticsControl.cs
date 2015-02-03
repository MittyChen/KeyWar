using UnityEngine;
using System.Collections;


public  enum PAUSE_BOX_TYPE{
	
	PAUSE_BOX_NORMAL = 0,
	PAUSE_BOX_FAILED = 1 ,
	PAUSE_BOX_LEVEL_DONE = 2
};

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
		player = GameObject.FindGameObjectWithTag ("player");
		tkanim =  player.GetComponent<tk2dSpriteAnimator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(player == null ){
			player = GameObject.FindGameObjectWithTag ("player");
			tkanim =  player.GetComponent<tk2dSpriteAnimator>();
		}
		if(longPress){
			player.transform.Translate( currentVelocity *  Time.deltaTime);
		}   

		if(tkanim.CurrentClip.name == "fly"  && Mathf.Abs( player.rigidbody.velocity.y) <= 0.2f){
			tkanim.Play ("stay");
		}
	}
	
	public void logButton(){
	}
	//	TouchPhase.Stationary
	public void touchLeft(){
		
		if (player.GetComponent<PlayerController>().playerState == 1 ) {
			currentVelocity = new Vector3 ( runVelocity.x, player.rigidbody.velocity.y, 0);
			tkanim.Play ("walkright");
			longPress = true;
		}
		 
	}
	
	public void touchRight(){
		if (player.GetComponent<PlayerController> ().playerState == 1) {
			currentVelocity = new Vector3 (-1 * runVelocity.x, player.rigidbody.velocity.y, 0);
			tkanim.Play ("leftwalk");
			longPress = true;
		}
	}


	public void touchUp(){
		if (player.GetComponent<PlayerController> ().playerState == 1  && Mathf.Abs( player.rigidbody.velocity.y ) <= 0.1f ) {
			if(longPress){
				 
				if (player.rigidbody.velocity.x < -0.02) {
					currentVelocity = new Vector3 (runVelocity.x, jumpVelocity.y, 0);
				} else if (player.rigidbody.velocity.x > 0.02) {
					currentVelocity = new Vector3 (-1 * runVelocity.x, jumpVelocity.y, 0);
				} else {
					currentVelocity = jumpVelocity; 
				}
			}else{
				currentVelocity = jumpVelocity; 
			} 
			longPress = false;// make the player not controlled by update
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
//		tkanim.Play ("stay");
	}


	public void showPauseBox(   )
	{
		if(GameObject.FindGameObjectWithTag ("pausenext")){
			GameObject.FindGameObjectWithTag ("pausenext").SetActive(false);
		}

		mask.SetActive (true);
		GameObject.FindGameObjectWithTag ("pause").GetComponent<UIPlayTween> ().playDirection = AnimationOrTween.Direction.Forward;
		GameObject.FindGameObjectWithTag ("pause").GetComponent<UIPlayTween> ().Play (true);
	}


	 
	public void showPauseBox( PAUSE_BOX_TYPE  mytype)
	{
		if (mytype == PAUSE_BOX_TYPE.PAUSE_BOX_NORMAL) {
			if(GameObject.FindGameObjectWithTag ("pausenext")){
				GameObject.FindGameObjectWithTag ("pausenext").SetActive(false);
			}
		} else if (mytype == PAUSE_BOX_TYPE.PAUSE_BOX_FAILED) {

			if(GameObject.FindGameObjectWithTag ("pausecancel")){
				GameObject.FindGameObjectWithTag ("pausecancel").SetActive(false);
			}


			if(GameObject.FindGameObjectWithTag ("pausenext")){
				GameObject.FindGameObjectWithTag ("pausenext").SetActive(false);
			}
		} else if (mytype == PAUSE_BOX_TYPE.PAUSE_BOX_LEVEL_DONE) {

			if(GameObject.FindGameObjectWithTag ("pausecancel")){
				GameObject.FindGameObjectWithTag ("pausecancel").SetActive(false);
			}

			if(GameObject.FindGameObjectWithTag ("pausenext")){
				GameObject.FindGameObjectWithTag ("pausenext").SetActive(true);
			}
		}
		mask.SetActive (true);
		GameObject.FindGameObjectWithTag ("pause").GetComponent<UIPlayTween> ().playDirection = AnimationOrTween.Direction.Forward;
		GameObject.FindGameObjectWithTag ("pause").GetComponent<UIPlayTween> ().Play (true);

	}

	public void closePauseBox()
	{
		mask.SetActive (false);
		GameObject.FindGameObjectWithTag ("pause").GetComponent<UIPlayTween> ().playDirection = AnimationOrTween.Direction.Reverse;
		GameObject.FindGameObjectWithTag ("pause").GetComponent<UIPlayTween>().Play(true);
	}





}
