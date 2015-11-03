using UnityEngine;
using System.Collections;

public class isRender : MonoBehaviour {

	//できる
	public void IsRender(GameObject obj)
	{

		if (obj.activeSelf == false) {
			obj.SetActive(true);
		} 
		else {
			obj.SetActive (false);
		}
	}

}
