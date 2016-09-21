using UnityEngine;
using System.Collections;
using System.IO;
using System;
using NCMB;
using UnityEngine.UI;

public class SaveImage : MonoBehaviour{
	public Camera camera;
	RenderTexture renderTexture;

	public void saveImage () {
		float width = Screen.width;
		float height = Screen.height;
	
		renderTexture = new RenderTexture (Screen.width, Screen.height, 0);
		camera.targetTexture = renderTexture;
		camera.Render ();

		RenderTexture.active = renderTexture;
		Texture2D virtualPhoto =
			new Texture2D((int)width, (int)height, TextureFormat.RGB24, false);
		// false, meaning no need for mipmaps
		virtualPhoto.ReadPixels( new Rect(0, 0, width, height), 0, 0);

		RenderTexture.active = null; //can help avoid errors 
		camera.targetTexture = null;

		byte[] bytes;
		bytes = virtualPhoto.EncodeToPNG();
		saveToCloud (bytes,getName());
	}
	void saveToCloud(byte[] bytes, string name){
		NCMBFile file = new NCMBFile (name, bytes);
		file.SaveAsync ((NCMBException error) => {
			if (error != null) {
				Debug.Log("upload image error");
				// 失敗
			} else {
				//成功
				Debug.Log("upload image success");
				Application.LoadLevel("blackboard");
			}
		});
	}

	string getName(){
		string name = "";
		name = name + DateTime.Now.Year+DateTime.Now.Month+DateTime.Now.Day+DateTime.Now.Hour+DateTime.Now.Minute+DateTime.Now.Second;
		name = name + ".png";
		return name;
	}
}
