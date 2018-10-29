using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

//	public float moveSpeed = 1.0f;
//
//
//
//		if (Input.GetKey (KeyCode.W)) {
//			this.transform.Translate (transform.up * moveSpeed);
//		}
//	}

//to control and rotate using 'wasd'
	public float moveSpeed = 1;
	public float rotateSpeed = 12;
	public float playerDamage = 10;
	public static int gold;
	public int initialGold = 0;

	void Awake(){
		gold = initialGold;
	}

	public static void UpdateGold(int newGold){
		gold += newGold;	
	}

	public static int getGold() {
		return gold;
	}

	// Update is called once per frame
	void Update () {
		//float moveVector = Input.GetAxis ("Vertical");
		//float rotateVector = Input.GetAxis ("Horizontal");

		float x = Input.GetAxis ("Horizontal") * Time.deltaTime * 3.0f;
		float z = Input.GetAxis ("Vertical") * Time.deltaTime * 3.0f;

		//transform.Rotate(0, x, 0);
		transform.Translate (x, z, 0);
		initialGold = gold;
	}
}
			//this.transform.Translate (0f, moveVector * moveSpeed * Time.deltaTime, 0f);

		//this.transform.Rotate (0f, 0f, rotateVector * (rotateSpeed * 10) * Time.deltaTime);

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
//	
