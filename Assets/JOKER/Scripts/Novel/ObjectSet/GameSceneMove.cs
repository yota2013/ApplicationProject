using UnityEngine;
using System.Collections;

public class GameSceneMove : MonoBehaviour {

	public void SceneMove(string name)
	{
		Application.LoadLevel(name);
	}

	void GameFinish()
	{
		Application.Quit();
	}
}
