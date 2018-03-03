using UnityEngine;
using System.Collections;

public class JumpablePlats : MonoBehaviour {

	private BoxCollider2D colliderD;
	private GameObject Player;

	// Use this for initialization
	void Start () {
		colliderD = gameObject.GetComponent<BoxCollider2D> (); 
		//Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time < .2f)
			return;
		else if (Time.time < 1f)
			Player = GameObject.FindGameObjectWithTag ("Player");
		
		if (Player.gameObject.transform.position.y < gameObject.transform.position.y)
			colliderD.isTrigger = true;
		
		if(!colliderD.isTrigger && Input.GetButtonDown("Down")) {
			colliderD.isTrigger = true;
		}

		if (!colliderD.isTrigger) {
			Player.GetComponent<PlayerMovement> ().isGrounded = true;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			StartCoroutine ("Formation");
		}
	}

	void OnTriggerExit2D(Collider2D col) {
	//	if (col.gameObject.tag == "Player" && col.gameObject.transform.position.y < gameObject.transform.position.y) {
	//		colliderD.isTrigger = false;
	//	}
	}

	IEnumerator Formation () {
		yield return new WaitForSeconds (.2f);
		colliderD.isTrigger = false;
		StopCoroutine ("Formation");
	}
}
