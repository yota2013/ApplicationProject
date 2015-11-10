using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using Novel;
//Canavas に setting


public class CreateBottom : MonoBehaviour {

	int _CHAPTRNUM = 2;
	List<string> _chapterFile;
	[SerializeField]
	RectTransform _prefab =null;

	void SetTextList()
	{
		FileReadList chapterlist = new FileReadList ();
		chapterlist.ReadFile ("Test");
		_chapterFile = chapterlist.Guitxt;
		_CHAPTRNUM = _chapterFile.Count;
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

		for(int i = 0; i < _CHAPTRNUM; i++)
		{
			RectTransform ChapterButton = GameObject.Instantiate(_prefab) as RectTransform;
			ChapterButton.SetParent(transform, false);
			var text = ChapterButton.GetComponentInChildren<Text>();
			text.text = (i+1).ToString() +"章:" + _chapterFile[i].ToString();
			MoveScene (ChapterButton,i+1);
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
