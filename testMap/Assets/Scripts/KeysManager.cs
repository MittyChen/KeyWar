using UnityEngine;
using System.Collections;

public class KeysManager : MonoBehaviour {
	public string keyType = "";
	public int keyCoding = 0;
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
			collision.collider.gameObject.GetComponent<PlayerController>().keyState = collision.collider.gameObject.GetComponent<PlayerController>().keyState | keyCoding;
			Destroy(gameObject);

			if(collision.collider.gameObject.GetComponent<PlayerController>().keyState == 1)
			{
				GameObject.FindGameObjectWithTag("uiorangekey").GetComponent<MeshRenderer>().enabled = true;
				GameObject.FindGameObjectWithTag("uiorangekey").GetComponent<BoxCollider>().enabled = true;
			}

			if(collision.collider.gameObject.GetComponent<PlayerController>().keyState == 3)
			{
				GameObject.FindGameObjectWithTag("uiyellowkey").GetComponent<MeshRenderer>().enabled = true;
				GameObject.FindGameObjectWithTag("uiyellowkey").GetComponent<BoxCollider>().enabled = true;
			}
		}
	}

}
