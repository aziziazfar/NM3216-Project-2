using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

	public float wallHealth = 50.0f;
	//public float cost = 5.0f,to be implemented later

	public void DamageToWall (float amount) {
		wallHealth -= amount;
		if (wallHealth <= 0.0f) {
			Destroy (gameObject);
		}
	}
}
