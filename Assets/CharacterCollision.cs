using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision cls) 
	{
		//Debug.Log ("Collision");

		if( cls.gameObject.tag == "Enemy" )
		{
			//Debug.Log ("Enemy");
			SmartBot enemy = cls.gameObject.GetComponent<SmartBot>(); // component of type class SmartBot (defined in another script)
			//if( enemy.getState() == "Attack" )
			  Destroy(gameObject);
		}
	}
}
