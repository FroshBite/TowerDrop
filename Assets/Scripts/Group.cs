using UnityEngine;
using System.Collections;

public class Group : MonoBehaviour {
	// Time since last gravity tick
	float lastFall = 0;
	float lastPressLeft=0;
	float lastPressRight=0;

	bool heldLeft=false;
	bool heldRight=false;

	Object spawner = Object.FindObjectOfType<Spawner>();

	bool isValidGridPos() {        
		foreach (Transform child in transform) {
			Vector2 v = Grid.roundVec2(child.position);
			
			// Not inside Border?
			if (!Grid.insideBorder(v)){
				return false;
			}
			
			// Block in grid cell (and not part of same group)?
			if (Grid.grid[(int)v.x, (int)v.y] != null &&
			    Grid.grid[(int)v.x, (int)v.y].parent != transform)
				return false;
		}
		return true;
	}

	void updateGrid() {
		// Remove old children from grid
		for (int y = 0; y < Grid.h; ++y)
			for (int x = 0; x < Grid.w; ++x)
				if (Grid.grid[x, y] != null)
					if (Grid.grid[x, y].parent == transform)
						Grid.grid[x, y] = null;
		
		// Add new children to grid
		foreach (Transform child in transform) {
			Vector2 v = Grid.roundVec2(child.position);
			Grid.grid[(int)v.x, (int)v.y] = child;
		}        
	}

	// Use this for initialization
	void Start () {
		// if the default position isn't even valid, game is lose
		if (!isValidGridPos()) {
			Debug.Log("GAME OVER");
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update() {
		// Move Left

		if (Input.GetButtonDown("Left")) {
			// Modify position
			transform.position += new Vector3(-1, 0, 0);
			
			// See if valid
			if (isValidGridPos()) {
				updateGrid();
			}
			else {
				transform.position += new Vector3(1, 0, 0);
			}

			lastPressLeft=Time.time;
			heldLeft=true;
		}

		else if(Input.GetButtonUp("Left")){
			heldLeft=false;
		}
		// Move Right

		else if (Input.GetButtonDown("Right")) {
			// Modify position
			transform.position += new Vector3(1, 0, 0);
			
			// See if valid
			if (isValidGridPos()){
				updateGrid();
			}
			else {
				transform.position += new Vector3(-1, 0, 0);
			}

			lastPressRight=Time.time;
			heldRight=true;
		}

		else if(Input.GetButtonUp("Right")){
			heldRight=false;
		}
		// Rotate

		else if (Input.GetButtonDown("Rotate")) {
			transform.Rotate(0, 0, -90);
			
			// See if valid
			if (isValidGridPos()) {
				updateGrid();
			}
			else {
				transform.Rotate(0, 0, 90);
			}
		}
		
		// Move Downwards and Fall

		else if (Input.GetButton("Drop") ||
		         Time.time - lastFall >= 1) {
			// Modify position
			transform.position += new Vector3(0, -1, 0);
			
			// See if valid
			if (isValidGridPos()) {
				updateGrid();
			}
			else {
				transform.position += new Vector3(0, 1, 0);
				
				// Clear filled horizontal lines
				Grid.deleteFullRows();
				
				// Spawn next Group
				spawner.spawnNext();
				spawner.changePreview();
				
				// Disable script
				enabled = false;
				gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
			}
			
			lastFall = Time.time;
		}

		else if(Input.GetButton ("Left") && (heldLeft==true&&Time.time-lastPressLeft>=0.3)){
			// Modify position
			transform.position += new Vector3(-1, 0, 0);
			
			// See if valid
			if (isValidGridPos()) {
				updateGrid();
			}
			else {
				transform.position += new Vector3(1, 0, 0);
			}
		}
		
		else if(Input.GetButton ("Right") && (heldRight==true&&Time.time-lastPressRight>=0.3)){
			// Modify position
			transform.position += new Vector3(1, 0, 0);
			
			// See if valid
			if (isValidGridPos()){
				updateGrid();
			}
			else {
				transform.position += new Vector3(-1, 0, 0);
			}
		}
		spawner.generateQueueObject ();
		spawner.changePreview ();
	}
}
