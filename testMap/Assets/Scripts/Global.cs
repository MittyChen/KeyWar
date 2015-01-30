using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {
	 
	 
	AudioSource bgmusic ;

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
		Destroy (GameObject.FindGameObjectWithTag ("gamescene"));
		Destroy (GameObject.FindGameObjectWithTag ("tilemap"));
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
