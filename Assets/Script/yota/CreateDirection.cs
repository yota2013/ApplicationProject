using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

//関数を呼び出せば，1ゲームプレイされるようにする．

public class CreateDirection : MonoBehaviour {
	//表示が何かを返すクラス
	private Sprite[] _arrow;
	private Sprite _NowArrow;
	private List<string> OnceArrow = new List<string>();
	private Animator _anim;

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
		OnceArrow.Add (_NowArrow.name);
		SpriteChange ();
	}

	IEnumerator MainPlay(int loop,float WaitTime){
		int i = 0;
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

	public List<string> GetOnceArrow()
	{
		return OnceArrow;
	}

	public void RemoveOneceArrow()
	{
		 OnceArrow.Clear ();
	}

}
