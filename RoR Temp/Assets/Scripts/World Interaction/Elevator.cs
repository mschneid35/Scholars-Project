using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {

	public float change = 0;
	public float speed = 0;

    public static float speede = 0;

	private float OriginalY;
	private bool moveUp = true;

	// Use this for initialization
	void Start () {
        speede = speed;
		OriginalY = gameObject.transform.position.y - .1f;
	}
	
	// Update is called once per frame
	void Update () {

		if (moveUp) {
			transform.position += new Vector3 (0, Time.deltaTime * speed, 0);
		} else {
			transform.position += new Vector3 (0, -Time.deltaTime * speed, 0);
		}

		if (transform.position.y > OriginalY + change )
			moveUp = false;
		else if (transform.position.y < OriginalY)
			moveUp = true;
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
            PlayerMovement.onElev = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        PlayerMovement.onElev = false;
    }
}
