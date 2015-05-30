using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour  {
	public float speed;
	public float gravity;
	public int jumpheight;

	Vector2 currentPosition;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().gravityScale = gravity;
		currentPosition=new Vector2(transform.position.x, transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		print (currentPosition);
		GetComponent<Rigidbody2D>().velocity = new Vector2 (speed,0);
	}
}
