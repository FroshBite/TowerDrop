using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {
	public GameObject enemy;

	private int maxWaves=5;
	private int waveSize = 5;
	private int initialWaveSize = 5;
	private int packSize = 5;
	private int initialPackSize = 5;

	//timers
	private int packTimer =0;
	private int mobTimer = 0;
	public int packBuffer = 500;
	private int mobBuffer = 60;

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
			packSize=initialPackSize;
			waveSize--;
		}

		if(packTimer==packBuffer){
			packTimer=0;
			spawnMode=true;
		}

		if (waveSize == 0) {
			waveSize=initialWaveSize;
			maxWaves-=1;
			initialPackSize++;
		}

		if (maxWaves == 0) {
			spawnMode=false;
			if(GameObject.Find("Enemy(Clone)") ==null){
				victory ();
			}
		}
	}

	public void victory(){
		Debug.Log ("You Win!");
	}

	public void createMob(){
		Instantiate (enemy, this.transform.position, Quaternion.identity);
	}
}
