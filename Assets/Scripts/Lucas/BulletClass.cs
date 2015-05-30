using UnityEngine;
using System.Collections;

public class BulletClass : MonoBehaviour {
	int i = 0;

	public float left_bound;

	void Update () {
		i += 1;

		if (i >= 4) {
			i = 0;
			MoveLeft();
		}

	}

	void MoveLeft(){

		// Move bullet left one position on the grid system

		Vector3 position = transform.position;
		position.x -= 1;
		transform.position = position;

		if (position.x < left_bound)
			Destroy(this.gameObject);
	}
	

	void OnCollisionEnter2D (Collision2D col){
		Debug.Log ("Collision with");
		Debug.Log (col.gameObject.tag);

		if (col.gameObject.tag == "Box") {
			Destroy(this.gameObject);
		}

	}

}
