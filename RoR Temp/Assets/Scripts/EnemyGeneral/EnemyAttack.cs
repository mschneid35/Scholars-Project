using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public float AttackDamage = 34;
	public float AttackSpeed = 2f;

	private bool attacking;

	private float AttackCD = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (EnemyChasing.inRange && !attacking && AttackCD <= Time.time) {
			AttackCD = AttackSpeed + Time.time;
			attacking = true;
			StartCoroutine ("AttackM");
		} else if(!EnemyChasing.inRange && attacking) {
			attacking = false;
			StopCoroutine ("AttackM");
		}
	}

	IEnumerator AttackM () {

		while (EnemyChasing.inRange) {
			PlayerHealth.HP -= AttackDamage;

			yield return new WaitForSeconds (AttackSpeed);
		}
	}
}
