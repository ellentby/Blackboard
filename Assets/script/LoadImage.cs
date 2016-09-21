using UnityEngine;
using System.Collections;
using NCMB;
using System.Collections.Generic;
using UnityEngine.UI;

public class LoadImage : MonoBehaviour {
	public List<Image> imageList;

	// Use this for initialization
	void Start () {
		for(int i=0; i<imageList.Count; i++){
			LoadOneImage (i, imageList[i]);
		}
	}

	public void LoadOneImage(int index, Image go){
		NCMBQuery<NCMBFile> query = NCMBFile.GetQuery ();
		query.Skip = index;
		query.Limit = 1;
		query.OrderByDescending ("createDate");
		query.FindAsync ((List<NCMBFile> objList, NCMBException error) => {
			if (error != null) {
				// 検索失敗
			} else {
				// 検索成功
				foreach (NCMBFile file in objList) {
					file.FetchAsync ((byte[] fileData, NCMBException e) => {
						if (e != null) {
							// 取得失敗
						} else {
							// 取得成功
							SaveBytes(fileData, go);
						}
					});
				}
			}
		});
	}
	void SaveBytes(byte[] b, Image go){
		Texture2D texture = new Texture2D (100,100);
		texture.LoadImage (b);
		Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
		go.sprite = sprite;
		Resources.UnloadUnusedAssets(); 
	}
}
