using UnityEngine;
using System.Collections;

public class EnemyChasing : MonoBehaviour {

	public GameObject Player;
	public float MoveSpeed;

	//private float MinDist = 1;
	//private float MaxDist;

	public float Speed;
	public bool lookingRight = false;
	public bool lookingLeft = true;
	private bool onGround = true;

	private CharacterController2D _controller;
	private Vector2 direction;
	private float _canFireIn;
	static public bool inRange;
    static public bool stunned = false;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		_controller = GetComponent<CharacterController2D> ();
		Physics2D.IgnoreCollision (gameObject.GetComponent<BoxCollider2D> (), Player.GetComponent<BoxCollider2D> ());
		Physics2D.IgnoreLayerCollision (12, 12);
		Physics2D.IgnoreLayerCollision (12, 13);
		MoveSpeed += (Random.Range (0f, 75f) * .01f);
		direction = new Vector2 (-1, 0);
		Speed = MoveSpeed;
		lookingRight = false;
		lookingLeft = true;
	}
	
	// Update is called once per frame
	void Update () {

		_controller.SetHorizontalForce (direction.x * MoveSpeed);
	//	MoveSpeed = Speed;

		if ((direction.x < 0 && _controller.State.IsCollidingLeft) || (direction.x > 0 && _controller.State.IsCollidingRight) || !onGround) {
			if (lookingLeft) {
				lookingLeft = false;
				lookingRight = true;
			} else if (lookingRight) {
				lookingLeft = true;
				lookingRight = false;
			}

			direction = -direction;
			transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
			onGround = true;
		}

		var raycast = Physics2D.Raycast (transform.position, direction, 10, 1 << LayerMask.NameToLayer ("Player"));
		var raycast2 = Physics2D.Raycast (transform.position, -direction, 5, 1 << LayerMask.NameToLayer ("Player"));
		if (!raycast && !raycast2) {
			return;
		}

		if (transform.position.x - Player.transform.position.x > .5 || (transform.position.y - Player.transform.position.y > 2 || transform.position.y - Player.transform.position.y < -2)) {
			inRange = false;
			if (lookingRight) {
				lookingRight = false;
				lookingLeft = true;
				transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				direction = -direction;
			}
		} else if (transform.position.x - Player.transform.position.x < -.5 || (transform.position.y - Player.transform.position.y > 2 || transform.position.y - Player.transform.position.y < -2)) {
			inRange = false;
			if (lookingLeft) {
				lookingLeft = false;
				lookingRight = true;
				transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				direction = -direction;
			}
		} else {
			MoveSpeed = 0;
			inRange = true;
		}

        if (!inRange && !stunned)
            MoveSpeed = Speed;
	}

	void OnTriggerEnter2D(Collider2D col) {
		onGround = true;
	}

	void OnTriggerExit2D(Collider2D col) {
		onGround = false;
	}
}
