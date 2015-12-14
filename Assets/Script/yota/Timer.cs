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
	private float limitTime = 50f;
	private bool isEnable = false;

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
	}
	
	// Update is called once per frame

	void Update() {
			if (_Direction.IsFlick == true) {
				CurrentTime -= Time.deltaTime;
				Debug.Log (CurrentTime);
				TimerSet (CurrentTime);
				 if (CurrentTime <= 0f) {
					Curtainprefab.GetComponent<Animator> ().SetBool ("Trigger",true);
					//ここに終了する関数
					//		return true;
				}
				//			return false;
			}

		}
	}

