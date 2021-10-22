using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMember : Robot
{

    //public PartyMember leader;
    
    

    private void FixedUpdate()
    {
        float distance = 1.05F * (GetComponent<CharacterController>().height/2);
        RaycastHit hit;
        Ray landingRay = new Ray(transform.position, Vector3.down);        

        if (Physics.Raycast(landingRay, out hit, distance))
        {
            grounded = true;
            canJump = true;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * (distance), Color.blue);
        }
        else
            grounded = false;

        
    }
    protected new void Start() 
    {
        base.Start();
        gravityScale = .12F;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    public void updatePosition(Robot leader)
    {
        SetDirection(leader);
        SetVelocity();

        float distance = DistanceFrom(leader);
        //  moveDirection.x = moveDirection.x < 0 ? Mathf.Floor(moveDirection.x) : Mathf.Ceil(moveDirection.x);
        //  moveDirection.z = moveDirection.z < 0 ? Mathf.Floor(moveDirection.z) : Mathf.Ceil(moveDirection.z);

        //Gives followers a buffer in how far they should be from leader
        if (distance > 6)
            Forward();
        else if (distance > 4)
            Forward(.75f);
        else
        {
            moveDirection.x = 0;
            moveDirection.z = 0;
            Forward();
        }

       // canJump = leader.canJump;  
        if (grounded == true && canJump == false)
            StartCoroutine("jump");


        gravity();
        turnCheck();
        turn();
    }

    

}
