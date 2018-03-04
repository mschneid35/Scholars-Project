using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player1Abilities : MonoBehaviour {

	public float Ability1Cooldown = 1f;
	static public float Ability1CD = 0;
	public Text Ability1Txt;

	public float Ability2Cooldown = 3f;
	static public float Ability2CD = 0;
	public Text Ability2Txt;

	public float Ability3Cooldown = 4f;
	static public float Ability3CD = 0;
	public Text Ability3Txt;

	public GameObject FireTransform;
    public GameObject WhipTransform;
	public GameObject Bullet;
	public GameObject Whip;

	private Rigidbody2D PlayerRigidBody;

	// Use this for initialization
	void Start () {
		PlayerRigidBody = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (PlayerMovement.LookR)
			FireTransform.transform.rotation = new Quaternion (0, 0, 0, 0);
		else if (!PlayerMovement.LookR)
			FireTransform.transform.rotation = new Quaternion (0, 0, 180, 0);

        if (GetComponent<PlayerMovement>().inWater)
            return;

		if(Input.GetButtonDown("Ability1") && Ability1CD < Time.time) {
            StartCoroutine("shoot");
			Ability1CD = Time.time + Ability1Cooldown;
		}
		else if(Input.GetButtonDown("Ability2") && Ability2CD < Time.time) {
			whipAbility ();
			Ability2CD = Time.time + Ability2Cooldown;
		}
		else if(Input.GetButtonDown("Ability3") && Ability3CD < Time.time) {
			dash ();
			Ability3CD = Time.time + Ability3Cooldown;
		}
	}
		
	void whipAbility () {
		GameObject whip = Instantiate (Whip, WhipTransform.transform.position, FireTransform.transform.rotation);
        whip.transform.parent = transform;
	}

	void dash () {
		if(!PlayerMovement.LookR)
			PlayerRigidBody.AddForce(Vector2.left * 500);
		else if(PlayerMovement.LookR)
			PlayerRigidBody.AddForce(Vector2.right * 500);
	}

	void Character1Supp () {
		StartCoroutine ("Ability4");
		//gameObject.GetComponent<PlayerMovement>().
	}

	IEnumerator shoot () {
		Instantiate (Bullet, FireTransform.transform.position, FireTransform.transform.rotation);
        yield return new WaitForSeconds(.1f);
    }
}
