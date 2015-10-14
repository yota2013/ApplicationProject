using UnityEngine;
using System.Collections;

public class test_macro : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	[macro name=FadeInBgm]

	//フェードイン再生開始　3秒かけて徐々に再生されます[p]
	[playbgm time="3" storage=test.mp3 loop=true]
	[endmacro]



}
