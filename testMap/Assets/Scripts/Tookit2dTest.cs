using UnityEngine;
using System.Collections;

public class Tookit2dTest : MonoBehaviour {

	tk2dSprite sprite  ;
	// Use this for initialization
	void Start () {
		sprite = GetComponent<tk2dSprite>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A)) {
			sprite.color = Color.red; 
			sprite.scale = new Vector3(0.1f, 0.1f, 0.1f);
		}
		if (Input.GetKeyDown(KeyCode.S)) {
			sprite.color = Color.white; 
			sprite.scale = new Vector3(0.1f, 0.3f, 0.3f);
		}
	}
}
