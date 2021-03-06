using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    Animator charAnim;
    private bool walkState = false;

	Vector3 directionVector;
	RaycastHit hitInfo;

    // Use this for initialization
    void Start () {
        charAnim = GetComponent<Animator>();
		directionVector = new Vector3(0,0,0);
    }
	
	// Update is called once per frame
	void Update ()
    {

		if( Input.GetMouseButton(0) )
		{
			// calculate a ray going from the camera towards the mouse pointer position
			Ray rayToPointer = Camera.main.ScreenPointToRay(Input.mousePosition);
			// cast the ray until it hits a collider ( returns true if hits)
			if( Physics.Raycast( rayToPointer, out hitInfo, 100) )
			{
				this.transform.LookAt( hitInfo.point ); // rotate the object
				directionVector = hitInfo.point - this.transform.position;
				if (directionVector.magnitude > 0.5) // trigger movement if the point is faraway
				{
					walkState = true;
					charAnim.SetTrigger("walk");
				}
				//Debug.DrawLine(ray.origin, hitPoint.point, Color.red);
			}
		}
			

		if (walkState == true && (hitInfo.point - this.transform.position).magnitude > 0.5)
        {
			    this.transform.Translate (0, 0, 0.1F); // move towards the hit point
        }
        else
        {
                charAnim.SetTrigger("stop");
			    walkState = false;
        }
    }
}
