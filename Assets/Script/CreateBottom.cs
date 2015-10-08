using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
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



	public void BottomPut()
	{

		for(int i=0; i < _chapternum; i++)
		{
			RectTransform ChapterBttom = GameObject.Instantiate(_prefab) as RectTransform;
			ChapterBttom.SetParent(transform, false);
			var text = ChapterBttom.GetComponentInChildren<Text>();
			text.text = "item:" + _chapterFile[i].ToString();
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
