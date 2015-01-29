using UnityEngine;
using System.Collections;

public class LevManager: MonoBehaviour {
	AudioSource bgmusic;
	// Use this for initialization
	void Start () {

		this.gameObject.GetComponent<UIButton> ().onClick.ToArray()[0].target = this;
		string currenvalue = gameObject.GetComponentsInChildren<UILabel> ()[0].text;
		gameObject.GetComponentsInChildren<UILabel>()[0].text =  currenvalue + "\n" + gameObject.name;

		bgmusic = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<AudioSource> ();
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

		loadTilePrefabs (currentLevelName);

		Instantiate (Resources.Load ("Prefabs/UI/gamesceneui"));

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
		GameObject.FindGameObjectWithTag ("levelscrollview").transform.position = new Vector3 (0,0,1000);

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

	public void changeBGMTOFight()
	{
		if(bgmusic.isPlaying)
		{
			bgmusic.clip = (AudioClip)Resources.Load("Audios/fightbm", typeof(AudioClip));//调用Resources方法加载AudioClip资源
			bgmusic.Play ();
		}

	}

}
