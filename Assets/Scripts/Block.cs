using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
<<<<<<< HEAD
	public int health=5;
=======
	public int health;
>>>>>>> 0bb5de2943372a8a6aee74b81396e53d0b5f20fa
	public GameObject deathAnimation;

	void destroy(){
		/*int x = (int)this.gameObject.transform.position.x;
		int y = (int)this.gameObject.transform.position.y;
		Debug.Log (x);
		Debug.Log (y);
		Grid.decreaseRowsAbove(x, y);*/
		Destroy(this.gameObject);
	}

	bool isDestroyed(){ 
		//checks if the block was destroyed

		if (health <= 0) {
			//GameObject death = GameObject.Instantiate(deathAnimation);
			//death.transform.position = this.transform.position;
			destroy ();
			return true;
		}

		return false;
	}

	public void takeDamage(int ammount){
		print (health);
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
				
		takeDamage (3);
		
	}

}
