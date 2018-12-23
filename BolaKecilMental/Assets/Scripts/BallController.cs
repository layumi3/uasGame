using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	public int force;
	int scoreP1;
	 int totalP1;
	int scoreP2;
	int totalP2;
	Rigidbody2D rigid;
	
	//public RandomPaddleController food;

	Text scoreUIP1;
	Text totalUIP1;
	Text scoreUIP2;
	Text totalUIP2;
	GameObject panelSelesai;
	GameObject panelSelingan;

	Text txPemenang;
	AudioSource audio;
	public AudioClip hitSound;
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
		Vector2 arah = new Vector2 (2, 0).normalized;
		rigid.AddForce (arah * force);
		scoreP1 = 0;
		totalP1 = 0;
		scoreP2 = 0;
		totalP2 = 0;

		scoreUIP1 = GameObject.Find ("Score1").GetComponent<Text> ();
		totalUIP1 = GameObject.Find ("Total1").GetComponent<Text> ();
		scoreUIP2 = GameObject.Find ("Score2").GetComponent<Text> ();
		totalUIP2 = GameObject.Find ("Total2").GetComponent<Text> ();
		panelSelingan = GameObject.Find ("PanelSelingan");
		panelSelesai = GameObject.Find ("PanelSelesai");
		panelSelingan.SetActive (false);
		panelSelesai.SetActive (false);

		audio = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")){
			ContinueGame();
		}
	}

	void ResetBall(){
		transform.localPosition = new Vector2 (0, 0);
		rigid.velocity = new Vector2 (0, 0);
	}
	private void OnCollisionEnter2D(Collision2D coll){
		audio.PlayOneShot (hitSound);
		if (coll.gameObject.name == "TepiKanan") {
			scoreP1 += 1;
			
			TampilkanScore ();
			if (scoreP1 ==5){
				totalP1 += 1;
				TampilkanTotal ();
				PauseGame();
				txPemenang = GameObject.Find ("Pemenang").GetComponent<Text> ();
				txPemenang.text = "Player Hijau Menang!" + totalP1;
				scoreP1 -=5;
			}

			if (totalP1 == 3) {
				panelSelesai.SetActive (true);
				panelSelingan.SetActive (false);
				txPemenang = GameObject.Find ("Pemenang").GetComponent<Text> ();
				txPemenang.text = "Player Hijau Menang!";
				Destroy (gameObject);
				return;
			}
			ResetBall ();
			Vector2 arah = new Vector2 (2, 0).normalized;
			rigid.AddForce (arah * force);

		}
		if (coll.gameObject.name == "TepiKiri") {
			scoreP2 += 1;

			TampilkanScore ();
			if (scoreP2 ==5){
				totalP2 += 1;
				TampilkanTotal ();
				PauseGame();
				txPemenang = GameObject.Find ("Pemenang").GetComponent<Text> ();
				txPemenang.text = "Player Orange Menang!" + totalP1;
				scoreP2 -=5;
			}
			if (totalP2 == 3) {
				panelSelesai.SetActive (true);
				panelSelingan.SetActive (false);
				txPemenang = GameObject.Find ("Pemenang").GetComponent<Text> ();
				txPemenang.text = "Player Orange Menang!";
				Destroy (gameObject);
				return;
			}
			ResetBall ();
			Vector2 arah = new Vector2 (-2, 0).normalized;
			rigid.AddForce (arah * force);

		}

		if(coll.gameObject.name=="Pad1"|| coll.gameObject.name=="Pad2"){
			float sudut = (transform.position.y - coll.transform.position.y) * 5f;
			Vector2 arah = new Vector2 (rigid.velocity.x, sudut).normalized;
			rigid.velocity = new Vector2 (0, 0);
			rigid.AddForce (arah * force * 2);
		}

	}

	void TampilkanScore(){
		Debug.Log ("Score P1: "+scoreP1+" Score P2: "+scoreP2);
		scoreUIP1.text = scoreP1 + "";
		scoreUIP2.text = scoreP2 + "";
	}
	void TampilkanTotal(){
		totalUIP1.text = totalP1 + "";
		totalUIP2.text = totalP2 + "";
	}

	void PauseGame(){
		 Time.timeScale = 0;
		 panelSelingan.SetActive (true);
	}
	private void ContinueGame()
    {
        Time.timeScale = 1;
        panelSelingan.SetActive (false);
    }
		
}
