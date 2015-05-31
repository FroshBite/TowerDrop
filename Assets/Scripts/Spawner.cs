using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	// Groups
	public GameObject[] groups;
	public GameObject[] specials;

	//Queue
	private Queue qBlocks = new Queue();
	private const byte QUEUE_LENGTH = 5;

	//Preview Location
	private Vector3 location = new Vector3 (25,0,0);
	private Transform lTransform;

	public void spawnNext() {
		initNextGroup ();
	}

	private void addToGroupQueue(GameObject group){
		if (qBlocks.Count < QUEUE_LENGTH) {
			qBlocks.Enqueue (group);
		}
	}

	public void generateQueueObject(){
		// Random Index
		int rollForGlory = Random.Range (1, 99);
		if (rollForGlory > 90) {
			int i = Random.Range (0, specials.Length);
			addToGroupQueue (specials[i]);
		}
		else{
			int i = Random.Range (0, groups.Length);
			addToGroupQueue (groups[i]);	
		}	
	}
	
	private void initNextGroup(){
		Instantiate ((GameObject)qBlocks.Dequeue(),
			            transform.position,
			            Quaternion.identity);
	}

	//Used for previews. Checks next queue item without removing it from the queue
	public GameObject checkNextGroup(){
		return (GameObject)qBlocks.Peek();
	}

	//Used to instantitate previews
	public void changePreview(){
		lTransform.position = location;
		Instantiate(checkNextGroup (),
		            lTransform.position,
		            Quaternion.identity);
	}

	void Start() {
		// Initial function called
		// 2 queue objects required to have a preview for the next one
		generateQueueObject ();
		generateQueueObject ();
		spawnNext();
	}

	void Update() {
		if (Input.GetButtonDown ("Reset")) {
			for (int x = 0; x < Grid.h; x++){
				Grid.deleteRow (x);
			}
			spawnNext ();
		}
	}
	
}