using UnityEngine;
using System.Collections;
using System.IO; //System.IO.FileInfo, System.IO.StreamReader, System.IO.StreamWriter
using System; //Exception
using System.Text; //Encoding
using System.Collections.Generic;

//UserManager : SingletonMonoBehaviour<UserManager>

public class FileReadList{

	public List<string> _guitxt = new List<string> ();

	public List<string> Guitxt
	{
		get
		{
			return _guitxt;
		}
	}
		
	//Read text
	public void ReadFile(string Filename){
		// FileReadTest.txtファイルを読み込む
		FileInfo fi = new FileInfo (Application.dataPath + "/Scnario/" + Filename);
		Debug.Log (fi);
		try {
			// 一行毎読み込み
			using (StreamReader sr = new StreamReader (fi.OpenRead (), Encoding.UTF8)) {
				int i = 0;
				while (sr.EndOfStream == false) {
					_guitxt.Add(sr.ReadLine().ToString());
				}	
			}
		} catch (Exception e) {
			// 改行コード 例外
			Debug.Log (_guitxt);
			_guitxt.Add(SetDefaultText ());
		}
	}

	// 改行コード処理
	string SetDefaultText(){
		return "C#あ\n";
	}

}
