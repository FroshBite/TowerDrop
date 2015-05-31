using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	public int health;
	public GameObject deathAnimation;

	void destroy(){
		Destroy(this.gameObject);
	}
	bool isDestroyed(){ 
		//checks if the block was destroyed

		if (health <= 0) {
			GameObject death = GameObject.Instantiate(deathAnimation);
			
			for (int i= 0; i < gameObject.transform.parent.gameObject.transform.childCount; i++){
				GameObject child = gameObject.transform.parent.gameObject.transform.GetChild (i).gameObject;
				child.GetComponent<Rigidbody2D>().isKinematic = false;
			}

			death.transform.position = this.transform.position;
			destroy ();
			return true;
		}

		return false;
	}

	public void takeDamage(int ammount){
		if (ammount > 0) {
			health -= ammount;
		}
		print ("Take Damage Called");
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		isDestroyed ();
	}

	void OnCollisionEnter2D (Collision2D col){
				
		takeDamage (3);
		
	}

}
