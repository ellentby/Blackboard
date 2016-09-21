using UnityEngine;
using System.Collections;

public class ScreenAdapter : MonoBehaviour {
	public GameObject leftTop;
	public GameObject rightTop;
	public GameObject leftBottom;
	public GameObject rightBottom;

	// Use this for initialization
	void Start () {
		Debug.Log (rightBottom.GetComponent<RectTransform>().offsetMin);
		Debug.Log (rightBottom.GetComponent<RectTransform>().offsetMax);
		//leftTop
		leftTop.GetComponent<RectTransform>().offsetMax = new Vector2(0, Screen.height/2);
		leftTop.GetComponent<RectTransform> ().offsetMin = new Vector2 (-Screen.width/2, 0);
		//rightTop
		rightTop.GetComponent<RectTransform>().offsetMin = new Vector2(0,0);
		rightTop.GetComponent<RectTransform> ().offsetMax = new Vector2 (Screen.width/2, Screen.height/2);
		//leftBottom
		leftBottom.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
		leftBottom.GetComponent<RectTransform> ().offsetMin = new Vector2 (-Screen.width/2, -Screen.height/2);
		//rightBottom
		rightBottom.GetComponent<RectTransform>().offsetMax = new Vector2(Screen.width/2, 0);
		rightBottom.GetComponent<RectTransform> ().offsetMin = new Vector2 (0, -Screen.height/2);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
