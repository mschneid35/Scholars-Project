using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 50f;
	public float JumpPower = 10f;
	public bool isGrounded;
	static public bool onLadder;
	static public bool LookR;
	static public bool nearLadder = false;
    static public bool onElev;

    public bool inWater = false;

    private bool submerged;
	private float JumpCDR = .75f;
	private float JumpDown;

	private float HAxis;
	private float VAxis;
	private Rigidbody2D RB2D;
	private Animator anim;

	// Use this for initialization
	void Start () {
		RB2D = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
		onLadder = false;
		nearLadder = false;
        onElev = false;
        inWater = false;
        submerged = false;
		//lookR = true;
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("LookR", LookR);
		anim.SetBool ("Climbing", onLadder);

		if (LookR)
			transform.localScale = new Vector3 (4, 4, 1);
		else if(!LookR)
			transform.localScale = new Vector3 (-4, 4, 1);

		if (Input.GetButtonDown ("Jump") && ((isGrounded && JumpDown < Time.time) || submerged)) {
			PlayerJump ();
			JumpDown = Time.time + JumpCDR;
		} else if (Input.GetButtonDown ("Jump") && onLadder) {
			PlayerJump ();
			RB2D.gravityScale = 3;
		}
	}

	void FixedUpdate () {
		if(!onLadder || (isGrounded && onLadder))
			PlayerMove ();

		if (onLadder) {
			PlayerClimb ();
			RB2D.gravityScale = 0;
		}
        else
            RB2D.gravityScale = 3;

        if (inWater && Input.GetButtonDown("Submerge"))
        {
            submerged = true;
            GameObject.Find("Water").GetComponent<BuoyancyEffector2D>().density = 0;
        }

        if (!inWater)
            submerged = false;


    }
		
	void PlayerMove() {
		HAxis = Input.GetAxis ("Horizontal");
		if(HAxis < 0) {
			//gameObject.GetComponent<SpriteRenderer> ().sprite = lookLeft;
			LookR = false;
		}
		else if(HAxis > 0) {
		//	gameObject.GetComponent<SpriteRenderer> ().sprite = lookRight;
			LookR = true;
		}

		transform.position += new Vector3 (speed * HAxis * Time.deltaTime, 0, 0);
	}

	void PlayerJump() {
		isGrounded = false;
		RB2D.AddForce (Vector2.up * JumpPower * 100);
	}

	void PlayerClimb () {
		VAxis = Input.GetAxis ("Vertical");

		if (VAxis > 0 || VAxis < 0)
			isGrounded = false;
		else
			isGrounded = true;

		transform.position += new Vector3 (0, speed * VAxis * Time.deltaTime, 0);
	}

	void OnCollisionEnter2D (Collision2D col) {
		if(col.gameObject.tag == "Floor")
			isGrounded = true;

		if (col.gameObject.tag == "LadderTop")
			isGrounded = true;

	}

	void OnCollisionExit2D (Collision2D col) {
		//if(col.gameObject.tag == "Floor")
		//	isGrounded = false;

		//if (col.gameObject.tag == "LadderTop")
		//	isGrounded = false;
	}
}
