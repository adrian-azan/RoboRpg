using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyMember : Robot
{

    //public PartyMember leader;   

    
    protected new void Start() 
    {

    }
       
 
    
    public void updatePosition(Robot leader)
    {
        SetDirection(leader);        
       
        float distance = DistanceFrom(leader);
        //  moveDirection.x = moveDirection.x < 0 ? Mathf.Floor(moveDirection.x) : Mathf.Ceil(moveDirection.x);
        //  moveDirection.z = moveDirection.z < 0 ? Mathf.Floor(moveDirection.z) : Mathf.Ceil(moveDirection.z);

        //Gives followers a buffer in how far they should be from leader
        if (distance > 8)
            SetVelocity();
        else if (distance > 6)
            SetVelocity(.75f);
        else
        {
            moveDirection.x = 0;
            moveDirection.z = 0;
            SetVelocity(0);
        }
       
        base.Update();
       
    }

    

}
