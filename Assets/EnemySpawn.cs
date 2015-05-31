using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {
	public GameObject enemy;

	private int maxWaves=20;
	private int waveSize = 5;
	private int packSize = 1;

	//timers
	private int packTimer =0;
	private int mobTimer = 0;
	private int packBuffer = 30;
	private int mobBuffer = 30;

	//Switch determines whether a wave is spawned or not
	private bool spawnMode = true;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (spawnMode == false) {
			packTimer++;
		} else {
			mobTimer++;
		}

		if (mobTimer == mobBuffer&&packSize>=0) {
			mobTimer=0;
			createMob();
			packSize--;
		}

		if (packSize == 0) {
			spawnMode=false;
			packSize=1;
		}

		if(packTimer==packBuffer){
			packTimer=0;
			spawnMode=true;
		}

	}

	public void victory(){
		Debug.Log ("You Win!");
	}

	public void createMob(){
		Instantiate (enemy, this.transform.position, Quaternion.identity);
	}
}
