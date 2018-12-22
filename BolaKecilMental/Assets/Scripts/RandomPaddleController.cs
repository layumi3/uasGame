using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPaddleController : MonoBehaviour {

	//public float kecepatan;
	//public string axis;
	//public float batasAtas;
	//public float batasBawah;
	public GameObject Rpad;

	public Transform TepiAtas;
	public Transform TepiBawah;
	public Transform TepiKiri;
	public Transform TepiKanan;

	// Use this for initialization
	void Start () {
		//padd=GameObject.FindGameObjectWithTag("padd");
	}

	public void Spawn(){
		int x = (int)Random.Range ((TepiKiri.position.x+1), (TepiKanan.position.x-1));
		int y = (int)Random.Range ((TepiBawah.position.y+1), (TepiAtas.position.y-1));
		Instantiate (Rpad, new Vector2 (x, y), Quaternion.identity);
	}
	
	// Update is called once per frame
	/*void Update () {


		float gerak = Input.GetAxis (axis) * kecepatan * Time.deltaTime;

		float nextPos = transform.position.y + gerak;
		if(nextPos > batasAtas){
			gerak = 0;
		}
		if(nextPos<batasBawah){
			gerak = 0;
		}
		transform.Translate (0, gerak, 0);
	} */
}
