using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NumberOfTimesCounts : MonoBehaviour {

	[SerializeField] Text _TimerOutput;
	private int _NumberOfTimes = 0;

	// Use this for initialization
	void Start () {
		_TimerOutput = gameObject.GetComponent<Text> ();
		TimerSet (0f);
	}

	void TimerSet(float T){
		_TimerOutput.text = "回数:" + (int)T;
	}

	// Update is called once per frame
	public void InclementNum()
	{
		_NumberOfTimes++;
		Debug.Log (_NumberOfTimes);
		TimerSet(_NumberOfTimes);
	}

}
