using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMember : Robot
{

    //public PartyMember leader;   

    
    protected new void Start() 
    {
        base.Start();
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
        if (distance > 8)
            Forward();
        else if (distance > 6)
            Forward(.75f);
        else
        {
            moveDirection.x = 0;
            moveDirection.z = 0;
            Forward();
        }
       
        base.Update();
    }

    

}
