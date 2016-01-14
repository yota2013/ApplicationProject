using UnityEngine;
using System.Collections;

public class RobotMove : MonoBehaviour {

	GameObject conveyor;
	private float speed;
	//speedを変更するときに


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position += Vector3.left * speed * Time.deltaTime;
	}

	void ChangeSpeed()
	{
	

	}
}
