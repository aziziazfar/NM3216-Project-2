using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

	//spawn points in clockwise direction
	public Vector2 startNorth = new Vector2(3.72f, 1.37f);
	public Vector2 startEast = new Vector2(-20.6f, -13.1f);
	public Vector2 startSouth = new Vector2(3.72f, -26.81f);
	public Vector2 startWest = new Vector2(-15.08f, -0.04f) ;

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

		startNorth = new Vector2(3.72f, 1.37f);
		startEast = new Vector2(-20.6f, -13.1f);
		startSouth = new Vector2(3.72f, -26.81f);
		startWest = new Vector2(-15.08f, -0.04f) ;

		Instantiate(WaveL1, startEast, transform.rotation);

		StartCoroutine ("Spawn");

	}
	
	// Update is called once per frame
	void Update () {
		if ((GameObject.FindGameObjectsWithTag ("Enemy") == null) && (waveNumber != 0)) {
			enemiesDead = true;
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

		Instantiate(WaveL1, startEast, transform.rotation);
		//}

	}

	IEnumerator Spawn(){
		if (waveNumber == 0)
			yield return new WaitForSeconds (6);
		else
			yield return new WaitForSeconds (2);

		if (enemiesDead) {
			Instantiate (WaveL1, startEast, transform.rotation);
			enemiesDead = false;
			waveNumber++;
		}
	}
}
