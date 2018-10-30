using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

	//spawn points in clockwise direction
	public Vector2 startNorth;
	public Vector2 startEast;
	public Vector2 startSouth;
	public Vector2 startWest;

	//different types of enemy to be initiated 
	public GameObject WaveL1;
	public GameObject EnemyL2;
	public GameObject EnemyL3;

	//keeps count on the current wavenumber
	public static int waveNumber;

	bool enemiesDead = true;

	public int numEnemies = 5;

	// Use this for initialization
	void Start () {
		waveNumber = 0;

		startNorth = new Vector2(0.19f, 24.81f);
		startEast = new Vector2(25.68f, -0.05f);
		startSouth = new Vector2(0.1f, -24.64f);
		startWest = new Vector2(-25.39f, 0.13f) ;

		//Instantiate(WaveL1, startEast, transform.rotation);

		StartCoroutine ("Spawn");

	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectsWithTag ("Enemy").Length == 0) {
			enemiesDead = true;
			Debug.Log ("No more enemies");
		}
	}

	void SpawnWave(){
//		int startPoint = Random.Range (1, 6);
//
//		switch (startPoint){
//
//		case 1:
		//if (waveNumber == 0) {
			//delay (5);
		//}

		//else {
			//delay(2);

	
		int startPoint = Random.Range (1, 5);
		Debug.Log (startPoint);
		if (startPoint == 1) {
			if (
			Instantiate (WaveL1, startEast, transform.rotation);
		}
		if (startPoint == 2) {
			Instantiate (WaveL1, startSouth, transform.rotation);
		}
		if (startPoint == 3) {
			Instantiate (WaveL1, startWest, transform.rotation);
		}
		if (startPoint == 4) {
			Instantiate (WaveL1, startNorth, transform.rotation);
		}
		//}

	}

	IEnumerator Spawn(){
		while (true) {
			Debug.Log (enemiesDead);
			if (waveNumber == 0)
				yield return new WaitForSeconds (0);
			if (waveNumber != 0)
				yield return new WaitForSeconds (1);

			if (enemiesDead) {
				SpawnWave ();
				enemiesDead = false;
				waveNumber++;
				Debug.Log ("Next Wave Imminent!");
			}
		}
	}
}
