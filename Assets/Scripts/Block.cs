using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	public static int health=5;
	public GameObject deathAnimation;

	void destroy(){
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
				
		//takeDamage (3);
		
	}

}
