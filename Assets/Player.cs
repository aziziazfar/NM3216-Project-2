using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

//	public float moveSpeed = 1.0f;
//	void Update() {
//		faceMouse ();
//	}
//
//	void faceMouse(){
//		Vector3 mousePosition = Input.mousePosition;
//		mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);
//
//		Vector2 direction = new Vector2 (
//		    mousePosition.x - transform.position.x,
//			mousePosition.y - transform.position.y
//		);
//
//		transform.up = direction;
//
//		if (Input.GetKey (KeyCode.W)) {
//			this.transform.Translate (transform.up * moveSpeed);
//		}
//	}

//to control and rotate using 'wasd'
	public float moveSpeed = 1;
	public float rotateSpeed = 12;
	public float playerDamage = 10;
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveVector = Input.GetAxis ("Vertical");
		float rotateVector = Input.GetAxis ("Horizontal");

		this.transform.Translate (0f, moveVector * moveSpeed * Time.deltaTime, 0f);
		this.transform.Rotate (0f, 0f, rotateVector * (rotateSpeed * 10) * Time.deltaTime);
	}

//	void OnTriggerEnter2D (Collider2D target) {
//		if (target.gameObject.tag == "Enemy") {
//			Attack (target.gameObject);
//		}
//	}
//
//	void Attack(GameObject target){
//		if (Input.GetKey (KeyCode.Space)) {
//			target.transform.GetComponent<EnemyL1> ().TakeDamage (playerDamage);
//		}
//	}
		
}
