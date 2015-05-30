using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour  {
	public float speed;
	public int damageGiven;
	public float gravity;
	public int jumpheight;
	public int attackTimeout;
	
	new Rigidbody2D rigidbody;
	float timeColliding=0;
	Vector2 currentPosition;

	void jump(){
		//rigidbody.AddForce(transform.up * jumpheight);
		this.rigidbody.velocity = new Vector2 (0, jumpheight);
	}

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D> ();
		rigidbody.gravityScale = gravity;
		currentPosition=new Vector2(transform.position.x, transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector2 (speed,0);
	}

	void OnCollisionStay2D(Collision2D col) {
		if(col.gameObject.name == "Block" && timeColliding>=attackTimeout){
			col.gameObject.GetComponent<Block>().takeDamage(damageGiven);
			timeColliding=0;
		}
		timeColliding = (int)Time.realtimeSinceStartup;
	}
}
