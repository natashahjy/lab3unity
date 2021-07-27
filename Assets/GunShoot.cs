using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour {

	private Animator gunAnimator;
	private AudioSource gunAudio;
	private RaycastHit hitInfo;
	public GameObject particleEffects;

	GameObject character;

	// Use this for initialization
	void Start () {
		gunAnimator = GetComponent<Animator>();
		gunAudio = GetComponent<AudioSource> ();

		character = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () 
	{
		const int DamageFromBullet = 1;

		if( Input.GetButtonDown("Fire1") ) 
		{
			gunAnimator.SetTrigger("Shoot");
			gunAudio.Play();

			Vector3 directiononOfFire = character.transform.forward;
			
			if (Physics.Raycast (transform.position, directiononOfFire, out hitInfo, 20))
			{
				//Debug.DrawLine (transform.position, hitInfo.point, Color.yellow);

				drawLine( (transform.position+hitInfo.point)/2, hitInfo.point, Color.blue);
				// send a message to the object corresponding to hitInfo
				hitInfo.transform.SendMessage( "HitByBullet",  DamageFromBullet, SendMessageOptions.DontRequireReceiver );
				GameObject particleEffect = Instantiate(particleEffects, hitInfo.point, Quaternion.identity) as GameObject;
			}				
		}
		else 
			gunAnimator.SetTrigger ("Stop");
	}


	void drawLine(Vector3 start, Vector3 end, Color color, float duration = 0.02f)
	{
		//Debug.Log ("Draw line");

		GameObject myline = new GameObject();
		myline.transform.position = start;
		myline.AddComponent<LineRenderer>();
		LineRenderer lr = myline.GetComponent<LineRenderer>();
		lr.material = new Material(Shader.Find("Standard"));

		lr.startColor = color;
		lr.endColor = color;
		lr.startWidth = 0.05f;
		lr.endWidth = 0.05f;
		lr.SetPosition (0, start);
		lr.SetPosition (1, end);
		GameObject.Destroy (myline, duration);
	}
}
