using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public float maxHP = 106f;

	static public float HP = 0;



	// Use this for initialization
	void Start () {
		HP = maxHP;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
