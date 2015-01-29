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


	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "player"){
			int playerKeys = other.gameObject.GetComponent<PlayerController>().keyState;
			if(playerKeys == 1)
			{
				if(doorType == "orange")
				{
					Destroy (gameObject);
				}

			}else if(playerKeys == 3)
			{
			    if(doorType == "yellow")
				{
					GameObject.FindGameObjectWithTag("winlogo").GetComponent<Animation>().Play();
					Destroy (gameObject);
					Debug.Log(" You win the game!!!");


				}
			}
		}
	}
}
