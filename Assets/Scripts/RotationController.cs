using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void Update () {
		//float moveVector = Input.GetAxis ("Vertical");
		//float rotateVector = Input.GetAxis ("Horizontal");

		Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 targetVector = mousePosition - transform.position;
		float step = 999 * Time.deltaTime;
		transform.up = Vector2.MoveTowards (transform.up, -targetVector, step);
	}
}
