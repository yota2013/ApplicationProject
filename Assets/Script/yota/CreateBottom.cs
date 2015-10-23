using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using Novel;
//Canavas に setting

public class CreateBottom : MonoBehaviour {

	int _chapternum = 1;
	List<string> _chapterFile;
	[SerializeField] GUISkin BottomSkin;
	[SerializeField]
	RectTransform _prefab =null;

	void SetTextList()
	{
		FileReadList chapterlist = new FileReadList ();
		chapterlist.ReadFile ("Test.txt");
		_chapterFile = chapterlist.Guitxt;
		_chapternum = _chapterFile.Count;
	}
		
	private void BottomCreate()
	{
		SetTextList ();
		BottomPut();

	}

	void MoveScene(RectTransform obj,int scnarioNumber)
	{
		Button button = obj.GetComponent<Button> ();

		button.onClick.AddListener (() => {
			NovelSingleton.StatusManager.callJoker("wide/scene"+ scnarioNumber,"");

		});
	}

	public void BottomPut()
	{

		for(int i=1; i <= _chapternum; i++)
		{
			RectTransform ChapterButton = GameObject.Instantiate(_prefab) as RectTransform;
			ChapterButton.SetParent(transform, false);
			var text = ChapterButton.GetComponentInChildren<Text>();
			text.text = "item:" + _chapterFile[i].ToString();
			MoveScene (ChapterButton,i);
		}
	}



	void ParentCanvasSet(GameObject childobj)
	{
		childobj.transform.SetParent (gameObject.transform);
	}

	void Start()
	{
		BottomCreate ();
	}



}
