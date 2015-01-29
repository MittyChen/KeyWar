using UnityEngine;
using System.Collections;

public class Toolkit2Danimi : MonoBehaviour {
	 
	bool walking = false;
	// Use this for initialization
	void Start () 
	{
		 
	}
//	// Update is called once per frame 
//	void Update ()
//	{
//		if (Input.GetKeyDown(KeyCode.A)) 
//		{
//			anim.Play("hit");
//			anim.animationCompleteDelegate = HitCompleteDelegate;
//		}
//		if (Input.GetKeyDown(KeyCode.D))
//		{
//			anim.Play("walk");
//			anim.animationCompleteDelegate = null;
//			walking = true;
//		}
//		if (Input.GetKeyDown(KeyCode.W)) 
//		{
//			anim.Play("idle");
//			anim.animationCompleteDelegate=null;
//			walking=false;
//		}
//	￼}


	void Update(){
		if(Input.GetKeyDown(KeyCode.A))
		{
 			GetComponent<tk2dSpriteAnimator>().Play("walk");
		}
	
	}
}