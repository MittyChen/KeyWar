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
		}
	}

}
