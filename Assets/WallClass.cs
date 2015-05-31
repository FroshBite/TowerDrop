using UnityEngine;
using System.Collections;

public class WallClass : MonoBehaviour {
	public int health;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D col){
		
		Debug.Log ("Collision with");
		Debug.Log (col.gameObject.tag);
		
		if (col.gameObject.tag == "Bullet") {
			health -= 1;
			if (health <= 0){
				Destroy(gameObject);
			}
		}
		
	}

}
