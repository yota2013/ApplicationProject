using UnityEngine;
using System.Collections;

public class TestMode : MonoBehaviour {

	//メインカメラに付いているタグ名
	private const string MAIN_CAMERA_TAG_NAME = "MainCamera";
	public Canvas canvas;
	public GameObject conveyor;

	//カメラに表示されているか
	private bool _isRendered = false;

	private void Update () {
		Debug.Log (canvas.GetComponent<RectTransform>().sizeDelta);
		Debug.Log (canvas.scaleFactor);
		Debug.Log (conveyor.transform.position);
		if(_isRendered){
			Debug.Log ("カメラに映ってるよ！");
		}
		//Debug.Log ("映ってない");
		_isRendered = false;
	}

	//カメラに映ってる間に呼ばれる
	private void OnWillRenderObject(){
		//メインカメラに映った時だけ_isRenderedを有効に
		if(Camera.current.tag == MAIN_CAMERA_TAG_NAME){
			_isRendered = true;
		}
	}

}

