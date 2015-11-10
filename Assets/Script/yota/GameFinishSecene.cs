using UnityEngine;
using System.Collections;

public class GameFinishSecene : MonoBehaviour {

	public void SceneMove(string name)
	{
		Application.LoadLevel(name);
	}

	public void GameFinish()
	{
		Application.Quit();
		Debug.Log ("オワリ");
	}
}
