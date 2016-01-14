using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ConveyorMove : MonoBehaviour {
		public	Canvas canvas;
		public float speed = 10;
		private int spriteCount = 2;//Screen上以外の他のObjectが何個あるか
		private Vector2 ScreenSize;
		
	void Start()
		{
			ScreenSize = canvas.GetComponent<RectTransform> ().sizeDelta;
		}

		void Update () {
			// 左へ移動

//		if(ScreenSize.x >= -(transform.position + Vector3.left * speed * Time.deltaTime).x)
//		{

			transform.position += Vector3.left * speed * Time.deltaTime;

//		}
		//else
		//{
			//transform.position += new Vector3((ScreenSize.x -(ObjectRect().position.x))*Time.deltaTime,0,0);
		//}
		Debug.Log(ScreenSize.x);
		Debug.Log(ObjectRect().transform.position.x);

		if(ScreenSize.x <= - ObjectRect().position.x)
		{
			Debug.Log("Screen Out");
			ReverseConveyor ();

		}

		//transform.position += Vector3.left * speed * Time.deltaTime;

		}

	void ReverseConveyor()
		{
		//	canvas.GetComponent<RectTransform>().sizeDelta.x 
			// スプライトの幅を取得
		float width = ObjectRect().sizeDelta.x;
			// 幅ｘ個数分だけ右へ移動
		transform.position += new Vector3(ObjectRect().sizeDelta.x*4f,0f,0f) * 0 +new Vector3(ScreenSize.x,0f,0f)* spriteCount;
			//Debug.Log ("Camera Out");
		}

	RectTransform ObjectRect()
	{
		return gameObject.GetComponent<RectTransform> ();
	}

}