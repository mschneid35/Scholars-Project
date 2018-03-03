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

	public float Ability4Cooldown = 5f;
	static public float Ability4CD = 0;
	public Text Ability4Txt;

	public GameObject FireTransform;
    public GameObject WhipTransform;
	public GameObject Bullet1;
	public GameObject Bullet2;

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
			Character1Shoot ();
			Ability1CD = Time.time + Ability1Cooldown;
		}
		else if(Input.GetButtonDown("Ability2") && Ability2CD < Time.time) {
			Character1KnockBack ();
			Ability2CD = Time.time + Ability2Cooldown;
		}
		else if(Input.GetButtonDown("Ability3") && Ability3CD < Time.time) {
			Character1Dash ();
			Ability3CD = Time.time + Ability3Cooldown;
		} /*
		else if(Input.GetButtonDown("Ability4") && Ability4CD < Time.time) {
			Character1Supp ();
			Ability4CD = Time.time + Ability4Cooldown;
		}*/
	}

	void Character1Shoot () {

		StartCoroutine ("Ability1");

	}
		
	void Character1KnockBack () {
		GameObject whip = Instantiate (Bullet2, WhipTransform.transform.position, FireTransform.transform.rotation);
        whip.transform.parent = transform;
	}

	void Character1Dash () {
		if(!PlayerMovement.LookR)
			PlayerRigidBody.AddForce(Vector2.left * 500);
		else if(PlayerMovement.LookR)
			PlayerRigidBody.AddForce(Vector2.right * 500);
	}

	void Character1Supp () {
		StartCoroutine ("Ability4");
		//gameObject.GetComponent<PlayerMovement>().
	}

	IEnumerator Ability1 () {
		Instantiate (Bullet1, FireTransform.transform.position, FireTransform.transform.rotation);
        yield return new WaitForSeconds(.1f);
    }

	/*IEnumerator Ability4 () {

		for (int i = 0; i < 6; i++) {
			Instantiate (Bullet1, FireTransform.transform.position, FireTransform.transform.rotation);

			yield return new WaitForSeconds (.1f);
		}
	}*/
}
