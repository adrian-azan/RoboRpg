using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMember : Robot
{

    public PartyMember leader;
    public bool canJump = true;

    void Start() 
    {
        if (GetComponent<CharacterController>() == null)
            controller = new CharacterController();
        moveDirection = new Vector3(0, 0, 0);

        PartyMember current = leader;
        while (current != null)
        {
            Physics.IgnoreCollision(controller, current.controller, true);
            current = current.leader;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (leader != null)
        {
            updatePosition();
        }
    }

    void updatePosition()
    {
        //Find angle from partyMember to leader
        Vector3 leaderPos = leader.transform.position;
        Vector3 directionToTarget = transform.position - leaderPos;
        float angle = Vector3.SignedAngle(Vector3.left, directionToTarget, Vector3.up) + 180;
        angle = Mathf.Deg2Rad * angle;

        //Made y 0 so that all distances are only counting the x/z plane
        leaderPos.y = 0;
        Vector3 xz = transform.position;
        xz.y = 0;

        if (!leader.grounded)
            moveDirection.y = leader.moveDirection.y;

        moveDirection = new Vector3(1F, moveDirection.y, 1F);



        float distance = (leaderPos - xz).magnitude;
        moveDirection.x = -moveDirection.x * Mathf.Cos(angle) * speed;
        moveDirection.z = moveDirection.z * Mathf.Sin(angle) * speed;

        //Gives followers a buffer in how far they should be from leader
        if (distance > 8)
            controller.Move(moveDirection * Time.deltaTime);
        else if (distance > 6)
            controller.Move(moveDirection * .75F * Time.deltaTime);
        else
        {
            moveDirection.x = 0;
            moveDirection.z = 0;
            controller.Move(moveDirection * Time.deltaTime);
        }


        if (leader.canJump == false)
            jump();

        gravity();
        //turn();
    }



}
