using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	public int health;
	void destroy(){
		Destroy(this.gameObject);
	}
	bool isDestroyed(){ //checks if the block was destroyed
		if (health <= 0) {
			destroy ();
			print ("Object Destroyed");
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
}
