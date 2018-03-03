using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float MaxHP;

	private float HP;
	private float dmg;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		HP = MaxHP;
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (HP <= 0) {
			Destroy (gameObject);
			GameManager.score += 100;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Bullet") {
			dmg = col.gameObject.GetComponent<Character1Bullet> ().BulletDMG;
			HP -= dmg;
			Destroy (col.gameObject);
		} else if (col.gameObject.name == "Whip(Clone)") {
			dmg = col.gameObject.GetComponent<WhipManager> ().dmg;
			HP -= dmg;

            StartCoroutine("Stun");
		}
	}

    IEnumerator Stun()
    {
        EnemyChasing.stunned = true;
        GetComponent<EnemyChasing>().MoveSpeed = 0;
        yield return new WaitForSeconds(.5f);

        EnemyChasing.stunned = false;
    }
}
