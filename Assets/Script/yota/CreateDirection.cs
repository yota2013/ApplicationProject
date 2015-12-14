using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

//関数を呼び出せば，1ゲームプレイされるようにする．

public class CreateDirection : MonoBehaviour {
	//表示が何かを返すクラス
	private Sprite[] _arrow;
	private Sprite _NowArrow;
	private List<string> _OnceArrow = new List<string>();
	private Animator _anim;
	private bool _IsFlick;

	public bool IsFlick
	{
		set{this._IsFlick = value;}
		get{return this._IsFlick;}
	}

	public List<string> OnceArrow
	{
		get{return this._OnceArrow;}
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

	//スプライトをランダムで選択して変更する
	void SpriteChoose()
	{
		_NowArrow = RandomString ();
		_OnceArrow.Add (_NowArrow.name);
		SpriteChange ();
	}



	IEnumerator MainPlay(int loop,float WaitTime){
		int i = 0;
		IsFlick = false;
		yield return new WaitForSeconds (WaitTime);

		while ( i < loop) {
			_anim.SetBool ("action",true);
			//o.7
			yield return new WaitForSeconds (WaitTime);
			SpriteChoose ();
			i++;
			_anim.SetBool ("action",false);
			//1.0
			yield return new WaitForSeconds (WaitTime);
		}
		IsFlick = true;
		_anim.SetBool ("action",true);

	}


	public void ArrowPlay(int times,float WaitTime)
	{
		StartCoroutine (MainPlay(times,WaitTime));
	}


	// Use this for initialization

	void Awake()
	{
		_arrow = Resources.LoadAll<Sprite> ("Picture/Arrow/");
		_anim = GetComponent<Animator>();
	}

	void Start () {
		//StartCoroutine (mainLoop(_Arrowroll));
	}



	public void RemoveOneceArrow()
	{
		_OnceArrow.Clear ();
	}

}
