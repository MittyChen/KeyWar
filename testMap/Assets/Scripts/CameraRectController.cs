using UnityEngine;
using System.Collections;

public class CameraRectController : MonoBehaviour {

	private GameObject player;
	private GameObject gamesceneUI;
	public Vector2 cameraMoveSpeed ;
	public Vector4 tileBoundry;

	public Vector2 triggerLine;



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if(gamesceneUI == null)
		{
			gamesceneUI =  GameObject.FindGameObjectWithTag ("gamescene"); 
		}


		if (player != null) {
			if(player.GetComponent<PlayerController> ().playerState == 1 ){
				if (player.transform.position.x >= triggerLine.x && this.gameObject.transform.position.x < tileBoundry.y) {
					transform.Translate (cameraMoveSpeed.x * Time.deltaTime, 0, 0);
					gamesceneUI.transform.Translate(cameraMoveSpeed.x * Time.deltaTime, 0, 0);
				}else if (player.transform.position.x <= triggerLine.x && this.gameObject.transform.position.x > tileBoundry.x){
					transform.Translate (-1 * cameraMoveSpeed.x * Time.deltaTime, 0, 0);
					gamesceneUI.transform.Translate(-1 * cameraMoveSpeed.x * Time.deltaTime, 0, 0);
				}
				
				if (player.transform.position.y >= triggerLine.y && this.gameObject.transform.position.y < tileBoundry.w) {
					transform.Translate (0, cameraMoveSpeed.y * Time.deltaTime, 0);
					gamesceneUI.transform.Translate (0, cameraMoveSpeed.y * Time.deltaTime, 0);
				}else if (player.transform.position.y <= triggerLine.y && this.gameObject.transform.position.y > tileBoundry.z) {
					transform.Translate (0, -1 * cameraMoveSpeed.y * Time.deltaTime, 0);
					gamesceneUI.transform.Translate (0, -1 * cameraMoveSpeed.y * Time.deltaTime, 0);
				}
			}

		} else {
			player = GameObject.FindGameObjectWithTag ("player"); 
		}



		 


	}
}
