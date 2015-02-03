using UnityEngine;
using System.Collections;

public class LevManager: MonoBehaviour {
	// Use this for initialization
	public  static string currentLevel = "-1";


	void Start () {

		this.gameObject.GetComponent<UIButton> ().onClick.ToArray()[0].target = this;
//		string currenvalue = gameObject.GetComponentsInChildren<UILabel> ()[0].text;
//		gameObject.GetComponentsInChildren<UILabel>()[0].text =  currenvalue + "\n" + gameObject.name;

		string currenvalue = gameObject.GetComponentsInChildren<tk2dTextMesh> ()[0].text;
		gameObject.GetComponentsInChildren<tk2dTextMesh>()[0].text =  currenvalue + "\n   " + gameObject.name;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*
	level prefabs Transform

	position : -4.6 -3

	scale 0.011 0.011 0.1
	
	 */
	public void loadGameLevel()
	{
		hideThisScene();

		string currentLevelName = "Prefabs/Levels/level_prefab_" + this.gameObject.name;

		currentLevel = this.gameObject.name;

		loadTilePrefabs (currentLevelName);

		Instantiate (Resources.Load ("Prefabs/UI/gamesceneui"));

		Instantiate (Resources.Load ("Prefabs/player/player"));

		Instantiate (Resources.Load ("Prefabs/UI/boundries"));
	}


	private void loadTilePrefabs(string name)
	{
		Object myLevel = Resources.Load(name);
		
		GameObject levelscene = Instantiate (myLevel) as GameObject;
		
		levelscene.GetComponent<tk2dTileMap> ().renderData.transform.localScale = levelscene.transform.localScale;
		
		levelscene.GetComponent<tk2dTileMap> ().renderData.transform.position = levelscene.transform.position;
		
		levelscene.GetComponent<tk2dTileMap> ().renderData.transform.rotation = levelscene.transform.rotation;

		changeBGMTOFight ();
	}


	private void hideThisScene()
	{
		Destroy (GameObject.FindGameObjectWithTag("levelselect"));
	}




	public delegate void ButtonEventDelegate ();
	
	GameObject loadScene;

	public void doThingsWithLoading()
	{ 
//		GameObject.FindGameObjectWithTag ("levelscrollview").transform.position = new Vector3 (0,0,4000);

		GameObject.FindGameObjectWithTag ("scrollviewcamera").SetActive (false);

		loadScene = Instantiate (Resources.Load ("Prefabs/Scene/Loading")) as GameObject;
		
		StartCoroutine(WaitAndGoto(3.0F,new ButtonEventDelegate(loadGameLevel)));
	}

	//param . mevent means the things to do after time waits
	IEnumerator WaitAndGoto(float waitTime,ButtonEventDelegate mevent)  
	{
		yield return new WaitForSeconds(waitTime);
		Destroy (loadScene);
		mevent ();
	}

	public static void changeBGMTOFight()
	{
		if(Global.bgmusic.isPlaying)
		{
			Global.bgmusic.clip = (AudioClip)Resources.Load("Audios/fightbm", typeof(AudioClip));//调用Resources方法加载AudioClip资源
			Global.bgmusic.Play ();
		}

	}

}
