using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	// Groups
	public GameObject[] groups;
	public GameObject[] specials;
	public GameObject queueSpot;

	private Vector3 queuePosition;

	//Queue
	private Queue qBlocks = new Queue();
	private const byte QUEUE_LENGTH = 5;

	//Preview Location

	private Vector3 location = new Vector3 (25,6,0);


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
		int rollForGlory = Random.Range (80, 99); // for testing reasons, leave the left bound really high for higher specials drop
		if (rollForGlory > 90) {
			int i = Random.Range (0, specials.Length);
			addToGroupQueue (specials[i]);
		}
		else{
			//Debug.Log (i);
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
//	public void changePreview(){
//		staticGrid.position = location;
//		Instantiate(checkNextGroup (),
//		            staticGrid.position,
//		            Quaternion.identity);
//	}

	void Start() {
		// Initial function called
		// 2 queue objects required to have a preview for the next one
		generateQueueObject ();
		generateQueueObject ();
		spawnNext();
		queuePosition = queueSpot.transform.position;

		GameObject skeleton = GameObject.Instantiate (enemy);
		Vector3 pos = new Vector3 (1.5775f, 0.8206f, 0f);

		skeleton.transform.position = pos;
	}

	void Update() {
		for (int i =0; i<4; i++) {

			GameObject childQueue = queueSpot.transform.GetChild (i).gameObject;
			GameObject next = checkNextGroup();
			GameObject childNext = checkNextGroup().transform.GetChild (i).gameObject;

			Vector3 nextPosition = next.transform.position;
			Vector3 queueNextPosition = childNext.transform.position;
			Vector3 newPosition = new Vector3(queuePosition.x+queueNextPosition.x-nextPosition.x ,queuePosition.y+queueNextPosition.y-nextPosition.y,0 );

			childQueue.GetComponent<SpriteRenderer>().sprite = childNext.GetComponent<SpriteRenderer>().sprite; 
			childQueue.transform.position = newPosition;
		}


		

		if (Input.GetButtonDown ("Reset")) {
			for (int x = 0; x < Grid.h; x++){
				Grid.deleteRow (x);
			}
			spawnNext ();
		}
	}
	
}