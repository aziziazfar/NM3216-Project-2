using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyL1 : MonoBehaviour {

	public float health = 10.0f;
	public float moveSpeed = 0.05f;
	public float wallDamage = 10.0f;

	public bool isDead = false;

	GameObject wall;

	public float attackRestTime = 10.0f;

	public Vector2 centerOfMap = new Vector2 (0, 0);

	public void Update() {
		transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x, transform.position.y), centerOfMap, moveSpeed * Time.deltaTime);
	}

	public void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Wall") {
			wall = other.gameObject;
			StartCoroutine ("AttackWall");
			//other.gameObject.GetComponent<Wall> ().DamageToWall (wallDamage);
			//Destroy(other.gameObject);
		}
	}
	public void OnTriggerExit2D (Collider2D other){
		if (other.gameObject.tag == "Wall") {
			StopCoroutine ("AttackWall");
			//other.gameObject.GetComponent<Wall> ().DamageToWall (wallDamage);
		}
	}

	IEnumerator AttackWall()  {
		while (true) {
			wall.GetComponent<Wall> ().DamageToWall(wallDamage);
			Debug.Log ("Wall is under siege!");
			yield return new WaitForSeconds (attackRestTime);
		}
	}

	//why are the enemies not taking damage
	public void TakeDamage(float amount) {
		health -= amount;
		if (health <= 0.0f) {
			Die ();
		}
	}

	void Die() {
		Destroy (gameObject);
		isDead = true;
	}
}
