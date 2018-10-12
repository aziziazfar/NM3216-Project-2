using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	//range can be balanced in the future by adjusting circleCollider2D radius in inspector
	Transform enemy;
	public Transform gunTip;
	public Transform turretLocation;

	public List<GameObject> enemiesInRange;
	//for now ignore the lists first, need to get the basics to work.
	//public ParticleSystem onHit;

	//shooting stuff
	public float fireWaitTime = 1.0f;
	public float damage = 10.0f;

//	void Awake() {
//		enemy = GameObject.FindWithTag ("Enemy").transform;
//	}

	void Update() {
		if (enemiesInRange != null) {
			Debug.Log(enemiesInRange[0].name);
			enemy = enemiesInRange[0].transform;
			transform.LookAt(enemy);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			enemiesInRange.Add (other.gameObject);
			enemy = enemiesInRange[0].transform;
			StartCoroutine ("Shooting"); //starts shooting at intervals, can be defined in inspector
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.tag == "Enemy") {
			enemiesInRange.Remove (other.gameObject);
			enemy = enemiesInRange[0].transform;
			StopCoroutine ("Shooting"); //end coroutine once object leaves range
		}
	}

	IEnumerator Shooting() {
	
		//EnemyL1 enemyTargeted = enemy.GetComponent<EnemyL1>();
		while (true) {
			EnemyL1 enemyTargeted = enemy.GetComponent<EnemyL1>();
			while (enemyTargeted.TakeDamage(damage)){
				enemyTargeted.TakeDamage(damage);
			}
			enemiesInRange.Remove(enemyTargeted.gameObject);
			enemy = enemiesInRange[0].transform;
			//Shoot ();
			Debug.Log (gameObject.name);
			yield return new WaitForSeconds (fireWaitTime);
		}
	}

	//shooting using a RayCast
	void Shoot() {

		// Vector2 turretPos = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);
		// turretLocation.position = turretPos;

		// RaycastHit2D hit = Physics2D.Raycast ((Vector2)turretLocation.transform.position, (Vector2) turretLocation.transform.up);

		//if (hit) {
		// 	Debug.Log(hit.transform.name);

		// 	EnemyL1 enemyTarget = hit.transform.GetComponent<EnemyL1>();
		// 	enemy = enemyTarget.gameObject.transform;

		// EnemyL1 enemyTargeted = enemy.GetComponent<EnemyL1>();

		// //check if raycast actually hits a componente, eg Enemy Lv1.
		// //maybe can use switch case for enemies later, or multiple ifs? idk see how
		// if(enemyTargeted != null){
		// 	if (enemyTargeted.TakeDamage(damage)){
		// 	enemiesInRange.Remove(enemy.gameObject);
		// 	}
		// 	else {
		// 	Debug.Log("Shooting Enemy");
		// 	enemyTargeted.TakeDamage(damage);
		// 	}
		// }
		// else {
		// 	Debug.Log("FUCKING NULL CB FUCK");
		// }
		// if (enemyTarget != null) {
		// 	while (enemyTarget.TakeDamage (damage)) {
		// 		Destroy (enemyTarget.gameObject);
		// 	}
		// }
		//}
	}
}
