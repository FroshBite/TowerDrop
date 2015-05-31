using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	public int health = 3;
	public int damageGiven=15;
	public GameObject deathAnimation;

	void destroy(){
		int x = (int)this.gameObject.transform.position.x;
		int y = (int)this.gameObject.transform.position.y;;
		Grid.decreaseRowsAbove(x, y);
		Destroy(this.gameObject);
	}

	bool isDestroyed(){ 
		//checks if the block was destroyed

		if (health <= 0) {
			GameObject death = GameObject.Instantiate(deathAnimation);
			death.transform.position = this.transform.position;
			destroy ();


			return true;
		}

		return false;
	}


	public void takeDamage(int ammount){
		//damages the current object
		if (ammount > 0) {
			health -= ammount;
		}
		isDestroyed ();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D (Collision2D col){

		if (col.gameObject.tag == "Enemy") { //if the block collides with the enemy head
			if (col.collider == col.gameObject.GetComponent<Enemy> ().head) {
				col.gameObject.GetComponent<Enemy> ().takeDamage (damageGiven);
			}
		}
	}

}
