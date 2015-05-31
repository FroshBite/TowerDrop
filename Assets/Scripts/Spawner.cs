using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	// Groups
	public GameObject[] groups;
	public GameObject[] specials;

	public void spawnNext() {
		// Random Index
		int rollForGlory = Random.Range (90, 99);
		if (rollForGlory > 90) {
			int i = Random.Range (0, specials.Length);
			Instantiate (specials [i],
			             transform.position,
			             Quaternion.identity);
		} 
		else {
			int i = Random.Range (0, groups.Length);
			Instantiate (groups [i],
			             transform.position,
			             Quaternion.identity);
		}
	}

	void Start() {
		// initial
		spawnNext();
	}

	void Update() {
		if (Input.GetButtonDown ("Reset")) {
			for (int x = 0; x < Grid.h; x++){
				Grid.deleteRow (x);
			}
			spawnNext ();
		}
	}
	
}