﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	//range can be balanced in the future by adjusting circleCollider2D radius in inspector
	Transform enemy;
	public Transform gunTip;

	public List<GameObject> enemiesInRange;

	//shooting stuff
	public float fireRate = 3.0f;
	public float damage = 10.0f;

//	void Awake() {
//		enemy = GameObject.FindWithTag ("Enemy").transform;
//	}

//	void Update() {
//		if (enemiesInRange != null) {
//			enemy = enemiesInRange [0].transform;
//			transform.LookAt (enemy);
//		}
//	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			enemiesInRange.Add (other.gameObject);
			enemy = enemiesInRange [0].transform;
			StartCoroutine ("Shooting"); //starts shooting at intervals, can be defined in inspector
		}
	}

	void OnTriggerExit (Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			enemiesInRange.Remove (other.gameObject);
			StopCoroutine ("Shooting"); //end coroutine once object leaves range
		}
	}

	IEnumerator Shooting() {
		while (true) {
			transform.LookAt (enemy); // look at the enemy you intend to shoot
			Shoot ();
			yield return new WaitForSeconds (fireRate);
		}
	}

	//shooting using a RayCast
	void Shoot() {
		
		//EnemyL1 enemyTarget = enemy.GetComponent<EnemyL1> ();
		
		//damage the current enemy that turret is looking at
		enemy.GetComponent<EnemyL1>().TakeDamage (damage);
		if ((enemy.GetComponent<EnemyL1>().isDead && (enemiesInRange == null)) ||) { //considering that gameObject is destroyed and is now null
			enemiesInRange.Remove(enemy.gameObject);
			enemy = enemiesInRange [0].transform;
		}
//		RaycastHit2D hit;
//		if (Physics2D.Raycast(turretLocation, enemy.transform.up, out hit)) {
//			Debug.Log(hit.transform.name);
//
//			EnemyL1 enemyTarget = hit.transform.GetComponent<EnemyL1>();
//
//			//check if raycast actually hits a componente, eg Enemy Lv1.
//			//maybe can use switch case for enemies later, or multiple ifs? idk see how
//			if (TargetJoint2D != null) {
//				enemyTarget.TakeDamage(damage);
//			}
		//}
	}
}
