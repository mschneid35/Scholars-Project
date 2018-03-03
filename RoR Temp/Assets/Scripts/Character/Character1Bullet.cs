using UnityEngine;
using System.Collections;

public class Character1Bullet : MonoBehaviour {

	public float speed = 50f;
    public float BulletDMG = 10f;

    private Rigidbody2D RB;

	// Use this for initialization
	void Start () {
		RB = gameObject.GetComponent<Rigidbody2D> ();

		Destroy (gameObject, 5f);

		RB.velocity = gameObject.transform.right * speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col) {
			Destroy (gameObject);
	}
}
