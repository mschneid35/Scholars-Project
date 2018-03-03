using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject Spawnpoint;
	public GameObject Player;
	public GameObject[] Enemies;
	public GameObject[] EnemySpawnPoints;

	private float SpawnNum = 10f;
	static public float score = 0f;

	public Text[] AbilityTxts;
	public Text HpText;

	private GameObject PlayerObj;
	private float maxHP = 100;


	// Use this for initialization
	void Start () {
	//	PlayerObj = Instantiate (Player, Spawnpoint.transform.position, Spawnpoint.transform.rotation) as GameObject;
		StartCoroutine ("Spawns");
	//	maxHP = PlayerObj.GetComponent<PlayerHealth> ().maxHP;

	}
	
	// Update is called once per frame
	void Update () {
		if (Player1Abilities.Ability1CD - Time.time > -1) {
			AbilityTxts[0].text = "" + (int) (Player1Abilities.Ability1CD - Time.time + 1);
		}

		if (Player1Abilities.Ability2CD - Time.time > -1) {
			AbilityTxts[1].text = "" + (int) (Player1Abilities.Ability2CD - Time.time + 1);
		}

		if (Player1Abilities.Ability3CD - Time.time > -1) {
			AbilityTxts[2].text = "" + (int) (Player1Abilities.Ability3CD - Time.time + 1);
		}

		if (Player1Abilities.Ability4CD - Time.time > -1) {
			AbilityTxts[3].text = "" + (int) (Player1Abilities.Ability4CD - Time.time + 1);
		}

		HpText.text = PlayerHealth.HP + "/" + maxHP;

	//	Debug.Log (score);
	}

	IEnumerator Spawns () {
		for (int i = 0; i < SpawnNum; i++) {
			int rand = Random.Range (0, EnemySpawnPoints.Length);

			Instantiate (Enemies [0], EnemySpawnPoints [rand].transform.position, EnemySpawnPoints [0].transform.rotation);

			yield return new WaitForSeconds (5f);

		}
	}
}
