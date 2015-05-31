using UnityEngine;
using System;

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
		Vector2 xy  = GetOrientation ();
		pos.x += xy.x;
		pos.y += xy.y;
		fired_bullet.transform.position = pos;
		fired_bullet.GetComponent<BulletClass> ().direction = xy;
	}

	Vector2 GetOrientation() {
		float direction = (float) Math.Abs ( Math.Round (transform.rotation.z, 1) );
		Vector2 xy = new Vector2 (0, 0);

		if (direction == 0) {
			xy.x = -1;
		} else if (direction == 1) {
			xy.x = 1;
		} else {
			xy.y = 1;
		}
		
		Debug.Log (direction);

		return xy;
	}

	void destroy(){
		int x = (int)this.gameObject.transform.position.x;
		int y = (int)this.gameObject.transform.position.y;
		Debug.Log (x);
		Debug.Log (y);
		Grid.decreaseColumns(x, y);
		Destroy(this.gameObject);
	}

	bool isDestroyed(){ //checks if the block was destroyed
		if (health <= 0) {
			GameObject obj = GameObject.Instantiate(deathAnimation);
			obj.transform.position = this.transform.position;
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

}
