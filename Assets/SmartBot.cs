using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartBot : MonoBehaviour
{
    private Transform playerTransf;
    private Animator botAnimator;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerTransf = player.GetComponent<Transform>();

        botAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransf != null)
        {
            Vector3 direction = playerTransf.position - this.transform.position;
            direction.y = 0;

            float angleOfView = Vector3.Angle(direction, transform.forward);

            if (angleOfView < 40 && direction.magnitude < 10)
            {
                this.transform.rotation = Quaternion.LookRotation(direction);
                if (direction.magnitude < 1)
                {
                    botAnimator.SetTrigger("attack");
                    this.transform.Translate(0, 0, 0.04F);
                }
                else
                {
                    botAnimator.SetTrigger("run");
                    this.transform.Translate(0, 0, 0.2F);
                }
            }
            else
            {
                botAnimator.SetTrigger("idle");
            }
        }
       
        
    }
}
