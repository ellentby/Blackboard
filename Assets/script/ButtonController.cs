using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnSave(){
		GetComponent<SaveImage> ().saveImage ();
	}
	public void OnGallery(){
		Application.LoadLevel ("gallery");
	}
	public void OnToBackboard(){
		Application.LoadLevel ("blackboard");
	}

}
