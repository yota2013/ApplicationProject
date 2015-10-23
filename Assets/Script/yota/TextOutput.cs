using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using UnityEngine.UI;
using System.Collections.Generic;

//RequireComponent
//これでゲームオブジェクトに自動的にアタッチされる．

public class TextLineOutput : MonoBehaviour
{
	//テキスト読み込む関数 string 返す
	//テキスト出力関数　string 返す
	//一行ずつ読み込む

	public Text _text;

	private string FileExecte(string fileName)
	{
		string noveltext = Resources.Load("Scenario/"+fileName).ToString();
		if (noveltext == null) {
			Debug.Log("ノベルテキストを読みつけません");
		}
		return noveltext;
	}

	private string NobelTextOutput(string FileName)
	{
		return FileExecte (FileName);
	}

	void Start () {
		//どのシーンかみる
		//シーンとファイルネームを同じにする．

	}

	void Update()
	{
	
	}


	
}
