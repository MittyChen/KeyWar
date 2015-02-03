using UnityEngine;
using System.Collections;

public class DoorManager : MonoBehaviour {
	public string doorType = "";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}


	void OnCollisionEnter(Collision collision) {

		if (collision.collider.gameObject.GetComponent<PlayerController> () != null && collision.collider.gameObject.GetComponent<PlayerController> ().playerState != 1) {
			return ;		
		}

		if(collision.collider.gameObject.tag == "player"){
			int playerKeys = collision.collider.gameObject.GetComponent<PlayerController>().keyState;
			if(playerKeys == 1)
			{
				if(doorType == "orange")
				{ 

					GameObject.FindGameObjectWithTag("uiorangekey").GetComponent<MeshRenderer>().enabled = false;
					GameObject.FindGameObjectWithTag("uiorangekey").GetComponent<BoxCollider>().enabled = false;
					Destroy (gameObject);
				}

			}else if(playerKeys == 3)
			{
			    if(doorType == "yellow")
				{
					GameObject.FindGameObjectWithTag("winlogo").GetComponent<Animation>().Play();
					GameObject.FindGameObjectWithTag("uiyellowkey").GetComponent<MeshRenderer>().enabled = false;
					GameObject.FindGameObjectWithTag("uiyellowkey").GetComponent<BoxCollider>().enabled = false; 
					StartCoroutine(WaitAndFinishlevel(1.0F));
				}
			}
		}
	}

	IEnumerator WaitAndFinishlevel(float waitTime)  
	{
		yield return new WaitForSeconds(waitTime);
		Destroy (gameObject);
		JoySticsControl jc =  GameObject.FindGameObjectWithTag ("gamescene").GetComponent<JoySticsControl> ();
		jc.showPauseBox (PAUSE_BOX_TYPE.PAUSE_BOX_LEVEL_DONE);
	}
}
