using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour  {
	public float speed;
	public int damageGiven;
	public float attackTimeout;
	public int health;
	public float gravity;
	public int jumpHeight;

	public BoxCollider2D head;
	public BoxCollider2D body;

	new Rigidbody2D rigidbody;
	float timeColliding=0;
	
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D> ();
		rigidbody.gravityScale = gravity;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector2 (speed,0);
	}

	void destroy(){ //destroys the current object
		Destroy(this.gameObject);
	}

	bool isDestroyed(){ //checks if the block was destroyed
		if (health <= 0) {
			destroy ();
			return true;
		}
		return false;
	}
	public void takeDamage(int ammount){ //damages the current object
		if (ammount > 0) {
			health -= ammount;
		}
		isDestroyed ();
	}

	void OnCollisionStay2D(Collision2D col) {
		//When an enemy collides with a block

		if(col.gameObject.tag == "Box" && Time.realtimeSinceStartup-timeColliding>=attackTimeout){
			col.gameObject.GetComponent<CannonClass>().takeDamage(damageGiven);
			timeColliding=Time.realtimeSinceStartup;
		}

		if(col.gameObject.tag == "Block" && Time.realtimeSinceStartup-timeColliding>=attackTimeout){
			print ("enemy is colliding with a block");
			col.gameObject.GetComponent<Block>().takeDamage(damageGiven);
			timeColliding=Time.realtimeSinceStartup;
		}
	}
}
