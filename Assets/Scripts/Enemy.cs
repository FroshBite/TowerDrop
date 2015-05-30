using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour  {
	public float speed;
	public int damageGiven;
	public int attackTimeout;
	public float gravity;
	public int jumpHeight;

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

	void OnCollisionStay2D(Collision2D col) { //When an enemy collides with a block
		if(col.gameObject.tag == "Block" && timeColliding>=attackTimeout){
			col.gameObject.GetComponent<Block>().takeDamage(damageGiven);
			timeColliding=0;
		}
		timeColliding = (int)Time.realtimeSinceStartup;
	}
}
