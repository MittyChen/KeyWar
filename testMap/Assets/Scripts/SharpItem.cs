using UnityEngine;
using System.Collections;

public class SharpItem : MonoBehaviour {
	GameObject mplayer;
	// Use this for initialization
	void Start () {
		 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "player" && other.gameObject.GetComponent<PlayerController>().playerState == 1){
			mplayer = other.gameObject; 
			StartCoroutine(WaitAndLose(1.0F));
		}
	}


	IEnumerator WaitAndLose(float waitTime)  
	{
		yield return new WaitForSeconds(0.1f);

		mplayer.GetComponent<PlayerController>().playerState  = 0;
		mplayer.GetComponent<tk2dSpriteAnimator>().Play("pale");
		mplayer.rigidbody.velocity = new Vector3(0,3,0);
		mplayer.rigidbody.transform.Rotate(0,0,180);
		mplayer.collider.enabled = false; 
		yield return new WaitForSeconds(waitTime);  

		GameObject.FindGameObjectWithTag("loselogo").GetComponent<Animation>().Play();
		
	}  



}
