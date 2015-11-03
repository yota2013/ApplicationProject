using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;


//Debug用　操作ができるか
//flick (x,y)=(0,0) 右下

public class FlickGet : MonoBehaviour {

	public GameObject _flickButton;
		
	void OnEnable ()
	{
		TouchManager.Instance.FlickComplete += OnFlickComplete;
		TouchManager.Instance.TouchStart += OnTouchStart;
	}

	void OnDisable ()
	{
		TouchManager.Instance.FlickComplete -= OnFlickComplete;
		TouchManager.Instance.TouchStart -= OnTouchStart;
	}

	//タッチしたらオブジェクト消せる
	void OnTouchStart (object sender, CustomInputEventArgs e)
	{
		string text = string.Format ("OnTouchStart X={0} Y={1}", e.Input.ScreenPosition.x, e.Input.ScreenPosition.y);
		Debug.Log (text);
		//IsRender(_flickButton);

	}

	//フリック認識完了
	void OnFlickComplete (object sender, FlickEventArgs e)
	{
		string text = string.Format ("OnFlickComplete [{0}] Speed[{1}] Accel[{2}] ElapseTime[{3}]", new object[] {
			e.Direction.ToString (),
			e.Speed.ToString ("0.000"),
			e.Acceleration.ToString ("0.000"),
			e.ElapsedTime.ToString ("0.000")
		});
		//		Debug.Log (text);
		IsRender(_flickButton);
		Debug.Log ("test");
	}

	public void IsRender(GameObject obj)
	{


		if (obj.activeSelf == false) {
			obj.SetActive(true);
		} 
		else {
			obj.SetActive (false);
		}
	}

}
