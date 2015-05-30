using UnityEngine;
using System.Collections;

public class TowerClass : MonoBehaviour {

	public GameObject cannon;
	public float cannon_height;
	public int cannons;

	// Use this for initialization
	void Start () {

		// Generate three cannons as part of the tower object
		for (int i=0; i<cannons; i++) {

			GameObject obj = GameObject.Instantiate(cannon);
			obj.transform.parent = this.transform;

			// Update the height of each cannon to be y above the previous cannon
			Vector3 pos = obj.transform.localPosition;
			pos.y += i*cannon_height;
			obj.transform.position = pos;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
