using UnityEngine;
using System.Collections;

public class WhipManager : MonoBehaviour {

    public float dmg = 10f;

    private Rigidbody2D RB;

	// Use this for initialization
	void Start () {
		RB = gameObject.GetComponent<Rigidbody2D> ();

		Destroy (gameObject, .5f);
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Enemy")
			Destroy (gameObject, .2f);
	//	else
		//	Destroy (gameObject);
	}
}
