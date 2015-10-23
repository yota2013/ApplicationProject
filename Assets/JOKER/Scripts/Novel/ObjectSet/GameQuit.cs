using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameQuit : MonoBehaviour {

	void GameFinish()
	{
		Button button = this.GetComponent<Button> ();

		button.onClick.AddListener (() => {

			Application.Quit();
		});

	}

}
