using UnityEngine;
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
	void destroy(){
		Destroy (this.gameObject);
	}
	
	bool isDestroyed(){
		if (health <= 0) {
			destroy ();
			return true;
		}
		return false;
	}

	public void takeDamage(int ammount){
		if (ammount > 0) {
			health -= ammount;
		}
		isDestroyed ();
	}
	void OnCollisionEnter2D (Collision2D col){

	}

}
