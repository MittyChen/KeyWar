using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public int playerState= 1;
	tk2dSpriteAnimator tkanim;
	public Vector3 jumpVelocity;
	public Vector3 runVelocity;
	public int keyState;//[000->0] [001->1] [010->2] [100->4] [011->3] [110->6] [101->5]
	// Use this for initialization
	void Start () {
		  
		tkanim =   GetComponent<tk2dSpriteAnimator>();
	}
	
	// Update is called once per frame
	void Update () {
#if UNITY_EDITOR
		if(playerState == 1)
		{
			if (Input.GetKeyDown(KeyCode.A)  ) {
				rigidbody.velocity = new Vector3(-1 * runVelocity.x, rigidbody.velocity.y,0 );
				tkanim.Play("walkright");
			}
			if (Input.GetKeyDown(KeyCode.D)) {
				rigidbody.velocity = new Vector3( runVelocity.x, rigidbody.velocity.y,0 );;
				tkanim.Play("leftwalk");
			}
			
			if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) ) {
				tkanim.Play("stay");
			}
			if (Input.GetKeyDown(KeyCode.W)) { 
				if(tkanim.CurrentClip.name == "leftwalk")
				{
					rigidbody.velocity  = new Vector3( runVelocity.x, jumpVelocity.y,0 ); ;
				}
				else if(tkanim.CurrentClip.name == "walkright")
				{
					rigidbody.velocity  = new Vector3( -1 * runVelocity.x, jumpVelocity.y,0 ); ;
				}else{
					
					rigidbody.velocity  = new Vector3( jumpVelocity.x, jumpVelocity.y,0 ); ;
				}
				tkanim.Play ("fly");
				
			} 
			if (Input.GetKeyDown(KeyCode.S)) {
//				tkanim.Play("pale");
			}

		}

#endif

	}
}
