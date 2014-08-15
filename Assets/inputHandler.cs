﻿using UnityEngine;
using System.Collections;

public class inputHandler : MonoBehaviour {

	public float speed;
	public GUIText counterText;
	public GUIText winText;
	private int cnt;

	private bool NOANDROID;

	void Start() {
		NOANDROID = false; //Application.platform != RuntimePlatform.Android;

		cnt = 15;
		UpdateCounterText();
	}

	void FixedUpdate() {
		float move_vert = -Input.acceleration.x; //-1 * Input.GetAxis ("Horizontal");
		float move_hori = Input.acceleration.y; //Input.GetAxis ("Vertical");

		if(NOANDROID || (move_vert == 0 && move_vert == 0)) {
			move_vert = -1 * Input.GetAxis ("Horizontal");
			move_hori = Input.GetAxis ("Vertical");
		}

		Vector3 mov = new Vector3(move_hori, 0, move_vert);

		rigidbody.AddForce (mov * speed * Time.deltaTime);

	}

	void OnTriggerEnter(Collider col) {
		if(col.gameObject.tag.Equals("PickUp")) {
			col.gameObject.SetActive(false);

			cnt--;
			UpdateCounterText();

			if(cnt <= 0) {
				winText.gameObject.SetActive(true);
				Time.timeScale = 0;
			}
		} else if(col.gameObject.tag.Equals("Lava")) {
			winText.text = "You lose!";
			winText.color = Color.red;
			winText.gameObject.SetActive(true);
			Time.timeScale = 0;
		}
		print(col.gameObject.tag);
	}

	void UpdateCounterText() {
		counterText.text = "Count: " + cnt;
	}

}
