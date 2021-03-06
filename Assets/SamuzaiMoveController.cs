using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuzaiMoveController : MonoBehaviour {
	public float SPEED = 3.0F;
	enum Direction { LEFT, FWD, RIGHT, BACK};
    Direction currentDir;

    // Use this for initialization
    void Start () {
        currentDir = Direction.FWD;
	}
	
	// Update is called once per frame
	void Update () {
        float mvX = Input.GetAxis("Horizontal");
        float mvZ = Input.GetAxis("Vertical");
        //Debug.Log(mvX);

		// set the rotation angle around the axis Y
		if( mvX < 0 )
		{
			if( currentDir != Direction.LEFT ) {
				currentDir = Direction.LEFT;
				transform.eulerAngles = new Vector3 (transform.eulerAngles.x, -90F, transform.eulerAngles.z);
			}
        }
		else if ( mvX > 0 )
        {
			if( currentDir != Direction.RIGHT ) {
				currentDir = Direction.RIGHT;
				transform.eulerAngles = new Vector3 (transform.eulerAngles.x, 90F, transform.eulerAngles.z);
			}
        }
		else if ( mvZ > 0 )
        {
			if( currentDir != Direction.FWD ) {
				currentDir = Direction.FWD;
				transform.eulerAngles = new Vector3 (transform.eulerAngles.x, 0F, transform.eulerAngles.z);
			}
        }
		else if ( mvZ < 0 )
        {
			if( currentDir != Direction.BACK ) {
				currentDir = Direction.BACK;
				transform.eulerAngles = new Vector3 (transform.eulerAngles.x, 180F, transform.eulerAngles.z);
			}
        }

		/*
        // Translate forward
		if(mvX != 0 || mvZ !=0 )
		  transform.Translate( 0, 0, Time.deltaTime * SPEED );
		*/
    }
}
