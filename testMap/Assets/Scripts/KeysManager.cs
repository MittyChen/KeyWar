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
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "player"){
			other.gameObject.GetComponent<PlayerController>().keyState = other.gameObject.GetComponent<PlayerController>().keyState | keyCoding;
			Destroy(gameObject);

			if(other.gameObject.GetComponent<PlayerController>().keyState == 1)
			{
				GameObject.FindGameObjectWithTag("uiorangekey").GetComponent<MeshRenderer>().enabled = true;
				GameObject.FindGameObjectWithTag("uiorangekey").GetComponent<BoxCollider>().enabled = true;
			}

			if(other.gameObject.GetComponent<PlayerController>().keyState == 3)
			{
				GameObject.FindGameObjectWithTag("uiyellowkey").GetComponent<MeshRenderer>().enabled = true;
				GameObject.FindGameObjectWithTag("uiyellowkey").GetComponent<BoxCollider>().enabled = true;
			}
		}
	}

}
