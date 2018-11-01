using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	[SerializeField]
	private Image UIPopup;
	[SerializeField]
	private GameObject Pop;

	private Image instance;
	private GameObject canvas;

	private bool shouldDestroy = false;

	void Awake(){
		gold = initialGold;
		canvas = GameObject.Find ("Canvas");
	}
//	void Start(){
//		StartCoroutine (DestroyPopUps(instance));
//	}

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
			//this.transform.Translate (0f, moveVector * moveSpeed * Time.deltaTime, 0f);

		//this.transform.Rotate (0f, 0f, rotateVector * (rotateSpeed * 10) * Time.deltaTime);
	IEnumerator DestroyPopUps (Image target){
		Debug.Log ("COROTUINE STARTED");
		yield return new WaitForSeconds (1);

		if (shouldDestroy) {
			Destroy (target);
		}
	}
	void OnTriggerEnter2D (Collider2D target) {
		if (target.gameObject.tag == "Turret") {
//			Debug.Log ("Interact POPUP");
//			GameObject item = Instantiate (Pop);
//			Vector2 playerPos = new Vector2 (transform.position.x, transform.position.y);
//
//			item.transform.SetParent (transform, false);
//			item.transform.position = playerPos;
			if (instance == null)
				CreatePopUp ();

			shouldDestroy = true;
			StartCoroutine (DestroyPopUps(instance));
			StopCoroutine (DestroyPopUps (instance));
		}
	}

	void OnTriggerExit2D (Collider2D target) {
		if (target.gameObject.tag == "Turret") {
			//Destroy (instance);
		}
	}

	void Attack(GameObject target){
		target.transform.GetComponent<EnemyL1> ().TakeDamage (playerDamage);
	}
	void CreatePopUp(){
		instance = Instantiate (UIPopup);
		Vector2 playerPos = new Vector2 (transform.position.x, transform.position.y);

		instance.transform.SetParent (canvas.transform, false);
		instance.transform.position = playerPos;
	}

}
//	
