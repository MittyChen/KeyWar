using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {
	 
	private Vector3 cameraOriPosition =  Vector3.zero ;
	public static AudioSource bgmusic ;

	// Use this for initialization
	void Start () {
		if(bgmusic == null){
			bgmusic = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<AudioSource> ();
		}

		int audioison = PlayerPrefs.GetInt ("AUIDO_ON");

		if(audioison == 1|| audioison == 0 ){
			if(!bgmusic.isPlaying)
			{
				bgmusic.Play();
			}

		}
 
		if (this.gameObject.tag == "mainmenu") {
			this.GetComponentInChildren<tk2dUIToggleButton>().IsOn = bgmusic.isPlaying;
		}
		cameraOriPosition = GameObject.FindGameObjectWithTag ("MainCamera").transform.position;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	GameObject loadScene;
	public void activeGame()
	{
		loadScene = Instantiate (Resources.Load ("Prefabs/Scene/Loading")) as GameObject;
		
		StartCoroutine(WaitAndGotoLevels(1.0F));
	}

	IEnumerator WaitAndGotoLevels(float waitTime)  
	{
		yield return new WaitForSeconds(1.0f);

		Destroy (loadScene);
//		GameObject.FindGameObjectWithTag ("mainmenu").SetActive (false);

		Instantiate (Resources.Load ("Prefabs/Scene/LevelSelect"));
		Destroy (GameObject.FindGameObjectWithTag ("mainmenu"));
	}

	public void mainSceneToLevels()
	{

		Instantiate (Resources.Load ("Prefabs/Scene/LevelSelect"));
		Destroy (GameObject.FindGameObjectWithTag ("mainmenu"));
	}

	public void destroyGameScene(){
		GameObject.FindGameObjectWithTag ("MainCamera").transform.position = cameraOriPosition;
		Destroy (GameObject.FindGameObjectWithTag ("gamescene"));
		Destroy (GameObject.FindGameObjectWithTag ("tilemap"));
		Destroy (GameObject.FindGameObjectWithTag ("player"));
		Destroy (GameObject.FindGameObjectWithTag ("gamebackground"));


	}

	public void gametoMainScene()
	{
		destroyGameScene ();
		changeBGMTOMenu ();
		Instantiate (Resources.Load ("Prefabs/Scene/menuscene"));
	}
	
	public void gameToLevelSelectScene()
	{
		destroyGameScene ();
		changeBGMTOMenu ();
		Instantiate (Resources.Load ("Prefabs/Scene/levelselect"));
	}

	public void gotoLevelFromGameWithLoading()
	{
		loadScene = Instantiate (Resources.Load ("Prefabs/Scene/Loading")) as GameObject;
		
		StartCoroutine(WaitAndGoto(0.5F,new ButtonEventDelegate(gameToLevelSelectScene)));
	}


	public void levelsToMainScene()
	{
		Destroy (GameObject.FindGameObjectWithTag ("levelselect"));
		Instantiate (Resources.Load ("Prefabs/Scene/menuscene"));
	}
	
	public delegate void ButtonEventDelegate ();


	public void doThingsWithLoading()
	{
		loadScene = Instantiate (Resources.Load ("Prefabs/Scene/Loading")) as GameObject;
		
		StartCoroutine(WaitAndGoto(0.5F,new ButtonEventDelegate(mainSceneToLevels)));
	}


	public void reloadGame()
	{
		destroyGameScene ();
		bgmusic.Stop ();
		string currentLevelName = "Prefabs/Levels/level_prefab_" + LevManager.currentLevel;
		loadTilePrefabs (currentLevelName);
		Instantiate (Resources.Load ("Prefabs/player/player"));
		Instantiate (Resources.Load ("Prefabs/UI/boundries"));
		Instantiate (Resources.Load ("Prefabs/UI/gamesceneui"));

	}

	public void loadNextGame()
	{
		destroyGameScene ();
		bgmusic.Stop ();


		int levelnum = int.Parse (LevManager.currentLevel);
		Debug.Log ("levelnum" +  levelnum);

		int nextLevelNum = levelnum + 1;
		string nextlevel = "";
		if (nextLevelNum < 10) {
			nextlevel = "0" + nextLevelNum;
		} else {
			nextlevel = "" + nextLevelNum;	
		}
		LevManager.currentLevel = nextlevel;
		string currentLevelName = "Prefabs/Levels/level_prefab_" + nextlevel;
		loadTilePrefabs (currentLevelName);
		Instantiate (Resources.Load ("Prefabs/player/player"));
		Instantiate (Resources.Load ("Prefabs/UI/boundries"));
		Instantiate (Resources.Load ("Prefabs/UI/gamesceneui"));
	
	}


	private void loadTilePrefabs(string name)
	{
		Object myLevel = Resources.Load(name);

		if(!myLevel){
			myLevel = Resources.Load("Prefabs/Levels/level_prefab_01");
		}
		GameObject levelscene = Instantiate (myLevel) as GameObject;
		
		levelscene.GetComponent<tk2dTileMap> ().renderData.transform.localScale = levelscene.transform.localScale;
		
		levelscene.GetComponent<tk2dTileMap> ().renderData.transform.position = levelscene.transform.position;
		
		levelscene.GetComponent<tk2dTileMap> ().renderData.transform.rotation = levelscene.transform.rotation;

		LevManager.changeBGMTOFight ();
	}



	public void reloadWithLoading()
	{
		loadScene = Instantiate (Resources.Load ("Prefabs/Scene/Loading")) as GameObject;
		
		StartCoroutine(WaitAndGoto(0.5F,new ButtonEventDelegate(reloadGame)));
	}
	public void loadNextLevelWithLoading()
	{
		loadScene = Instantiate (Resources.Load ("Prefabs/Scene/Loading")) as GameObject;
		
		StartCoroutine(WaitAndGoto(0.5F,new ButtonEventDelegate(loadNextGame)));
	}






	//param . mevent means the things to do after time waits
	IEnumerator WaitAndGoto(float waitTime,ButtonEventDelegate mevent)  
	{
		yield return new WaitForSeconds(waitTime);
		Destroy (loadScene);
		mevent ();
	}


	public void controlTheAudio()
	{
		if (!bgmusic.isPlaying) {
			bgmusic.Play ();
			PlayerPrefs.SetInt ("AUIDO_ON",1);
		} else
		{
			bgmusic.Pause();
			PlayerPrefs.SetInt ("AUIDO_ON",2);
		}
	}


	public void changeBGMTOMenu()
	{
		if (bgmusic.isPlaying) {
			bgmusic.clip = (AudioClip)Resources.Load("Audios/menubm01", typeof(AudioClip));//调用Resources方法加载AudioClip资源
			bgmusic.Play ();	
		}
	}

	

}
