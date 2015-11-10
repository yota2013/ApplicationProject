using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class DirectionFlick : MonoBehaviour {

	// Use this for initialization
	private List<string> OnceArrow = new List<string>();
	private int _number = 0;
	[SerializeField] Text _debug;

	void OnEnable ()
	{
		TouchManager.Instance.FlickComplete += OnFlickComplete;
	}
	void OnDisable ()
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
		Debug.Log (e.Direction.ToString());

		if (IsDirection (e.Direction.ToString ())&&OnceArrow != null) 
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
		OnceArrow  = CreateDirection.Instance.GetOnceArrow ();
		if (OnceArrow[_number] == Direction) {
			Debug.Log ("true");
			_number++;
			Corrent (_number);
		} else
		{
			Debug.Log("false");
			_number = 0;
		}
	}

	void Corrent(int NumberDirection)
	{
		if(NumberDirection == OnceArrow.Count)
		{
			Application.Quit ();
			Debug.Log ("OK");
		}
		Debug.Log (_number);
	}

	void Start()
	{
		_debug.text = "オワリ";
	}

}
