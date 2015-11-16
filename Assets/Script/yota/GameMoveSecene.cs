﻿using UnityEngine;
using System.Collections;

public class GameMoveSecene : MonoBehaviour {

	public void SceneMove(string name)
	{
		Debug.Log (name);
		Application.LoadLevel(name);
	}

	public void GameFinish()
	{
		Application.Quit();
		Debug.Log ("オワリ");
	}
}
