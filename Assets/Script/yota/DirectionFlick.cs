using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class DirectionFlick : MonoBehaviour {

	// Use this for initialization
	private List<string> OnceArrow = new List<string>();
	private int _number = 0;
	[SerializeField] Text _debug;
	private CreateDirection _Direction;
	private float DEFALUTTIMES = 0.5f;

	void OnEnable ()
	{
		TouchManager.Instance.FlickComplete += OnFlickComplete;
	}

	void OnDisable() 
	{
		TouchManager.Instance.FlickComplete -= OnFlickComplete;
	}

	void OnFlickComplete (object sender, FlickEventArgs e)
	{
		string text = string.Format ("OnFlickComplete [{0}] Speed[{1}] Accel[{2}] ElapseTime[{3}]", new object[] {
			e.Direction.ToString (),
			e.Speed.ToString ("0.000"),
			e.Acceleration.ToString ("0.000"),
			e.ElapsedTime.ToString ("0.000")
		});

		_debug.text = e.Direction.ToString ();

		if(_Direction.IsFlick != true)//矢印が出ている状況にあるかどうか
		{
			Debug.Log ("入力出来ないよ");
		}
		else if (IsDirection (e.Direction.ToString ())&&OnceArrow != null) 
		{
			CorrentAnswer (e.Direction.ToString ());
		}
	}

	public bool IsDirection (string Direction)
	{
		if (Direction == "None")
		{
			return false;
		}
		return true;
	}


	//nameでSpriteの名前を取得できる．
	private void CorrentAnswer(string Direction)
	{
		//受け渡しできた
		OnceArrow  = _Direction.OnceArrow;
		if (OnceArrow[_number] == Direction) {
			Debug.Log ("true");
			_number++;
			CorrentLastNum(_number);

		} 
		else
		{
			//間違ったときの判定
			Debug.Log("false");
			//Finish判定をここ入れる．
			_number = 0;
			ArrowPlays(3);
		}
	}

	//正解かどうかの関数
	void CorrentLastNum(int NumberDirection)
	{
		if(NumberDirection == OnceArrow.Count)
		{
			//Application.Quit ();
			ArrowPlays(3);
			Debug.Log ("OK");
			_number = 0;
		}
		Debug.Log (_number);
	}

	void ArrowPlays(int times)
	{
		_Direction.ArrowPlay (times,DEFALUTTIMES);
	}

	void Start()
	{
		_debug.text = "オワリ";
		_Direction = gameObject.GetComponent<CreateDirection> ();
		ArrowPlays(3);
	}



}
