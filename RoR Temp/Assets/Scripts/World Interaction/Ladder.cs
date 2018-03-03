using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {

	//static public bool nearLadder;
	public GameObject LadderTop;
	public GameObject Player;

	private bool onLadder2 = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerMovement.nearLadder && Input.GetButtonDown ("Vertical") && onLadder2) {
			PlayerMovement.onLadder = true;
		//	Physics2D.IgnoreCollision (LadderTop.GetComponent<BoxCollider2D> (), Player.GetComponent<BoxCollider2D> (), true);
			LadderTop.GetComponent<BoxCollider2D> ().isTrigger = true;

		}

		if(Input.GetButtonDown("Jump") || !PlayerMovement.nearLadder) {
			PlayerMovement.onLadder = false;
		//	Physics2D.IgnoreCollision (LadderTop.GetComponent<BoxCollider2D> (), Player.GetComponent<BoxCollider2D> (), false);
			LadderTop.GetComponent<BoxCollider2D> ().isTrigger = false;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			//col.gameObject.transform.position = new Vector3 (gameObject.transform.position.x, col.gameObject.transform.position.y, col.gameObject.transform.position.z);
			PlayerMovement.nearLadder = true;
			onLadder2 = true;
			//PlayerMovement.onLadder = true;
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			PlayerMovement.nearLadder = false;
			onLadder2 = true;
			//PlayerMovement.onLadder = false;
		}
	}
}
