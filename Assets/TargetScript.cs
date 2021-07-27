using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour {

	public int health = 3;

	// Use this for initialization
	void Start () {
		
	}

	void HitByBullet( int damage ) // process a message HitByBullet
	{
		health -= damage;
	}
	
	// Update is called once per frame
	void Update () {
		if (health < 1)
			Destroy(gameObject);
	}
}
