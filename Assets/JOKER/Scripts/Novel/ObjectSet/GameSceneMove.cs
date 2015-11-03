using UnityEngine;
using System.Collections;

public class GameSceneMove : MonoBehaviour {

	public void SceneMove(string name)
	{
		Application.LoadLevel(name);
	}
	//起動出来た
	public void GameFinish()
	{
		Application.Quit();
		Debug.Log ("オワリ");
	}
}
