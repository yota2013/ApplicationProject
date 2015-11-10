using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;


//Debug用　操作ができるか
//flick (x,y)=(0,0) 右下

public class DirectionPicture : MonoBehaviour {

	[SerializeField] Canvas _canvas;

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
		CreateDirectionObject ("Up");
	}

	//フリック認識完了
	//TODO:どの変数でどの向きにフリックしたかをみる．
	//deltaPostion
	void OnFlickComplete (object sender, FlickEventArgs e)
	{
		string text = string.Format ("OnFlickComplete [{0}] Speed[{1}] Accel[{2}] ElapseTime[{3}]", new object[] {
			e.Direction.ToString (),
			e.Speed.ToString ("0.000"),
			e.Acceleration.ToString ("0.000"),
			e.ElapsedTime.ToString ("0.000")
		});

		Debug.Log (e.Direction.ToString());
		if (IsCreateObject (e.Direction.ToString ())) 
		{
			CreateDirectionObject (e.Direction.ToString ());
		}
	}


	public bool IsCreateObject (string Direction)
	{
		if (Direction == "None")
		{
			return false;
		}

		return true;
	}

	private void CreateDirectionObject(string Direction)
	{
		GameObject buttonPrefab = Resources.Load ("prefab/"+Direction) as GameObject;
		GameObject button = Instantiate (buttonPrefab,new Vector2(0f,0f),Quaternion.identity) as GameObject;
		button.transform.SetParent (_canvas.transform);
		button.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0,0);

	}


	public void IsRender(GameObject obj)
	{
		if (obj.activeSelf == false) 
		{
			obj.SetActive(true);
		} 
		else 
		{
			obj.SetActive (false);
		}
	}

}
