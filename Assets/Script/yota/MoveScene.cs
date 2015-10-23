using UnityEngine;
using System.Collections;
using Novel;
using UnityEngine.UI;

public class MoveScene : MonoBehaviour {

	[SerializeField] string _scenarioName;

	//Use this for initialization
	void Start () {

		Button button = this.GetComponent<Button> ();

		button.onClick.AddListener (() => {

			NovelSingleton.StatusManager.callJoker("wide/"+_scenarioName,"");

		});

	}
}
