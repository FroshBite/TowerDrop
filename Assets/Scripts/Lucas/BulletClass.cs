using UnityEngine;
using System.Collections;

public class BulletClass : MonoBehaviour {
	public int damageGiven;


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
	void destroy(){
		Destroy (this.gameObject);
	}

	void OnCollisionEnter2D (Collision2D col){


		//the box tag is other canons
		if (col.gameObject.tag == "Box") {
			col.gameObject.GetComponent<CannonClass>().takeDamage(damageGiven);
		}

		//the canon hits an enemy
		if (col.gameObject.tag == "Enemy" ) {
			if (col.collider == col.gameObject.GetComponent<Enemy>().head)
				Debug.Log ("Head hit!");
			if (col.collider == col.gameObject.GetComponent<Enemy>().body)
				Debug.Log ("Body hit!");
			else
				Debug.Log ("????");
			col.gameObject.GetComponent<Enemy>().takeDamage(damageGiven);
		}

		Destroy (this.gameObject);

	}

}
