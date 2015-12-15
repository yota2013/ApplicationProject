using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Timer : MonoBehaviour {

	[SerializeField]GameObject Curtainprefab;
	private CreateDirection _Direction;
	private DirectionFlick Flickinfo;
	[SerializeField] GameObject Arrow;
	private Text TimerText;
	public float CurrentTime{ private set; get;}
	private float limitTime = 20f;
	private bool isEnable = false;
	public GameObject Temp;

	public bool IsEnable {
		get {
			return isEnable;
		}

		set {
			isEnable = value;
			if (!value) {
				CurrentTime = limitTime;
			}
		}
	}

	void TimerSet(float T){
		TimerText.text = "制限時間:" + (int)T;
	}
		

	// Use this for initialization
	void Start () {
		_Direction = Arrow.GetComponent<CreateDirection> ();
		TimerText = gameObject.GetComponent<Text> ();
		Flickinfo = Arrow.GetComponent<DirectionFlick>();
		TimerSet (limitTime);
		CurrentTime = limitTime;
		//Temp.GetComponent<Text> ().text = Temp.GetComponent<DirectionFlick>;
	}
	
	// Update is called once per frame

	void Update() {
			if (_Direction.IsFlick == true) {
				CurrentTime -= Time.deltaTime;
				Debug.Log (CurrentTime);
				TimerSet (CurrentTime);
				 if (CurrentTime <= 0f) {
					//ここに終了する関数
					Curtainprefab.GetComponent<Animator> ().SetBool ("Trigger",true);
				}
				//			return false;
			}

		}
	}

