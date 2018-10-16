using System.Collections;
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
	void Start () {
		StartCoroutine ("Shooting"); //starts shooting at intervals, can be defined in inspector
	}

	void Update() {
		if (enemiesInRange.Count > 0) {
			enemy = enemiesInRange [0].transform;
			transform.LookAt (enemy);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			enemiesInRange.Add (other.gameObject);
			//enemy = enemiesInRange [0].transform;

		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			enemiesInRange.Remove (other.gameObject);
			//StopCoroutine ("Shooting"); //end coroutine once object leaves range
		}
	}

	IEnumerator Shooting() {
		while (true) {
			Shoot ();
			//transform.LookAt (enemy); // look at the enemy you intend to shoot
			yield return new WaitForSeconds (fireRate);
		}
	}

	//shooting using a RayCast
	void Shoot() {
		
		//EnemyL1 enemyTarget = enemy.GetComponent<EnemyL1> ();
		
		//damage the current enemy that turret is looking at
		if (enemiesInRange.Count > 0) {
			enemy = enemiesInRange [0].transform;
			enemy.GetComponent<EnemyL1> ().TakeDamage (damage);
			if ((enemy.GetComponent<EnemyL1> ().isDead && (enemiesInRange != null))) { 
				enemiesInRange.Remove (enemy.gameObject);
				enemy = enemiesInRange [0].transform;
			}
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
