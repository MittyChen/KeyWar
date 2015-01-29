using UnityEngine;
using System.Collections;


public class ContentSet : MonoBehaviour {

	public  string contentTitle  = "Title";
	public  string contents = "contents";

	// Use this for initialization
	void Start () {
		UITextList mytext = GetComponent<UITextList>();
		mytext.Add (contentTitle);
//		mytext.Add ("\n\t");
		mytext.Add (contents);

		mytext.Add (contents);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
