using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class CreateDirection : SingletonMonoBehavior<CreateDirection> {
	//表示が何かを返すクラス
	private Sprite[] _arrow;
	private Sprite _NowArrow;
	private List<string> OnceArrow = new List<string>();
	int i = 0;
	private Animator _anim;

	IEnumerator mainLoop(int loop){
		int i = 0;
		while ( i < loop) {
			_anim.SetBool ("action",true);
			yield return new WaitForSeconds (0.7f);
			SpriteChoose ();
			i++;
			_anim.SetBool ("action",false);
			yield return new WaitForSeconds (1f);
		}
		_anim.SetBool ("action",true);
	}

	// Use this for initialization
	void Awake()
	{
		_arrow = Resources.LoadAll<Sprite> ("Picture/Arrow/");

	}

	void Start () {
		_anim = GetComponent<Animator>();
		StartCoroutine (mainLoop(3));
		//_NowArrow = gameObject.GetComponent<Image> ().sprite;
	}
		
	public List<string> GetOnceArrow()
	{
		return OnceArrow;
	}


	//ランダム関数作成
	//sprite で出力する．
	Sprite RandomString()
	{
		return _arrow[Random.Range(0,_arrow.Length)];
	}
	//スプライト変更
	void SpriteChange()
	{
		if(_NowArrow != null)
		{
			gameObject.GetComponent<Image> ().sprite = _NowArrow;
		}
	}

	void SpriteChoose()
	{
		_NowArrow = RandomString ();
		OnceArrow.Add(_NowArrow.name);
		SpriteChange ();
		Debug.Log (OnceArrow [i++]);
	}

}
