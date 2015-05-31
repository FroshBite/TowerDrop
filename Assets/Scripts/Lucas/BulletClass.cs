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
		Debug.Log ("Collision with "+col.gameObject.tag);

		//the bullet hits a block, destroy it 
		if (col.gameObject.tag == "Block") {
			destroy();
		}

		//the box tag is other canons
		if (col.gameObject.tag == "Box") {
			col.gameObject.GetComponent<CannonClass>().takeDamage(damageGiven);
			destroy();
		}

		//the canon hits an enemy
		if (col.gameObject.tag == "Enemy" ) {
			col.gameObject.GetComponent<Enemy>().takeDamage(damageGiven);
			destroy();
		}

	}

}
