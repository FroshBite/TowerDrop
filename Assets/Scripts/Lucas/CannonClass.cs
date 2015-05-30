﻿using UnityEngine;
using System.Collections;

public class CannonClass : MonoBehaviour {

	public GameObject bullet;
	public GameObject deathAnimation;
	public int shoot_rate;
	public float bullet_offset;
	public int health;

	int i = 0;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		// Every second, shoot a bullet
		i ++;
		if (i >= shoot_rate) {
			ShootBullet();
			i = 0;
		}

	}

	void ShootBullet() {
		GameObject fired_bullet = GameObject.Instantiate (bullet);
		Vector3 pos = this.transform.position;
		pos.x -= bullet_offset;
		fired_bullet.transform.position = pos;
	}
	
	void OnCollisionEnter2D (Collision2D col){

		Debug.Log ("Collision with");
		Debug.Log (col.gameObject.tag);
		
		if (col.gameObject.tag == "Bullet") {
			health -= 1;
			if (health <= 0){
				GameObject obj = GameObject.Instantiate(deathAnimation);
				obj.transform.position = this.transform.position;
				Destroy(gameObject);
			}
		}
		
	}

}
