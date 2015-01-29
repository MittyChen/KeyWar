using UnityEngine;
using System.Collections;

public class GameButtonControl : MonoBehaviour {
	public TweenAlpha mainMenuScene ;
	public TweenAlpha optionsScene ;
	public TweenAlpha aboutScene ;
	public TweenAlpha gameScene ;
	public TweenPosition gameRealScene ;

	private bool initEnd = false;
	AudioSource audio = null;
	float currentAudioVolume = 0.0f;
//	float initVolume = 0.0f;

	// Use this for initialization
	void Start () {

		audio= this.GetComponent<AudioSource> ();
		if (PlayerPrefs.GetInt ("AUDIO_ON") == -1) 
		{
			audio.Stop ();
			audio.volume =  0.0f;
			GameObject.FindGameObjectWithTag ("audioSlider").GetComponent<UISlider> ().value = 0;
			GameObject.FindGameObjectWithTag ("audiocheckbox").GetComponent<UIToggle> ().value = false;
		} else if (PlayerPrefs.GetInt ("AUDIO_ON") == 1 )  {
			audio.Play ();
			GameObject.FindGameObjectWithTag ("audioSlider").GetComponent<UISlider> ().value = PlayerPrefs.GetFloat ("AUDIO_VOLUME");
			audio.volume =  PlayerPrefs.GetFloat ("AUDIO_VOLUME");
			GameObject.FindGameObjectWithTag ("audiocheckbox").GetComponent<UIToggle> ().value = true;
		}else if( PlayerPrefs.GetInt ("AUDIO_ON") == 0)//first run game
		{
			audio.Play ();
			audio.volume =  1.0f;
			GameObject.FindGameObjectWithTag ("audioSlider").GetComponent<UISlider> ().value = 1.0f;
			GameObject.FindGameObjectWithTag ("audiocheckbox").GetComponent<UIToggle> ().value = true;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}


	public void gotoAboutScene()
	{
		aboutScene.PlayForward ();
		mainMenuScene.PlayForward ();
	}

	public void aboutToMainScene()
	{
		aboutScene.PlayReverse ();
		mainMenuScene.PlayReverse ();

	}

	public void optionsToMainScene()
	{
		PlayerPrefs.SetFloat ("AUDIO_VOLUME",GameObject.FindGameObjectWithTag ("audioSlider").GetComponent<UISlider> ().value); 
		optionsScene.PlayReverse ();
		mainMenuScene.PlayReverse ();
	}

	public void gotoOptionsScene()
	{
		optionsScene.PlayForward ();
		mainMenuScene.PlayForward ();
	}

	public void setVolume(){
		audio.volume = GameObject.FindGameObjectWithTag ("audioSlider").GetComponent<UISlider> ().value;
	}

	public void setVolumeOnorOff(){
				 
		if(initEnd){

			if (PlayerPrefs.GetInt ("AUDIO_ON") == 0) {
				audio.Play ();
				GameObject.FindGameObjectWithTag ("audioSlider").GetComponent<UISlider> ().value = 1.0f;
				PlayerPrefs.SetInt ("AUDIO_ON", 1);
			} else if (PlayerPrefs.GetInt ("AUDIO_ON") == 1 ) {
				audio.Stop ();
				currentAudioVolume = GameObject.FindGameObjectWithTag ("audioSlider").GetComponent<UISlider> ().value;
				GameObject.FindGameObjectWithTag ("audioSlider").GetComponent<UISlider> ().value = 0.0f;
				PlayerPrefs.SetInt ("AUDIO_ON", -1);
			} 
			else if(PlayerPrefs.GetInt ("AUDIO_ON") == -1 )
			{
				audio.Play ();
				PlayerPrefs.SetInt ("AUDIO_ON", 1);
				if(currentAudioVolume == 0)
				{
					currentAudioVolume = 1;
				}
				GameObject.FindGameObjectWithTag ("audioSlider").GetComponent<UISlider> ().value = currentAudioVolume;
			}
			Debug.Log ("AUDIO_ON"+PlayerPrefs.GetInt ("AUDIO_ON"));

		}




		initEnd = true;
	}

	public void startGame()
	{
		Debug.Log ("startGame");
		gameScene.PlayForward ();
		gameRealScene.PlayForward ();
		mainMenuScene.PlayForward ();
		GameObject ps =  GameObject.Find("leafemmiter");
		ps.GetComponent<ParticleSystem> ().Stop ();


		StartCoroutine(WaitAndDo(2.0F));  



	}

	IEnumerator WaitAndDo(float waitTime)  
	{    
		yield return new WaitForSeconds(waitTime);  

		//		GameObject boxs =  GameObject.Find("boxs");
		//		boxs.active = true;


		Debug.Log ("WaitAndDo"); 
	}    


	public void gameToMainScene()
	{
		GameObject ps =  GameObject.Find("leafemmiter");
		ps.GetComponent<ParticleSystem> ().Play ();
		mainMenuScene.PlayReverse ();
		gameScene.PlayReverse ();
		gameRealScene.PlayReverse ();
	}
}
