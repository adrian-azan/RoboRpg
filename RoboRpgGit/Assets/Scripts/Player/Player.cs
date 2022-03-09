using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Abstraction.Collider;

public class Player : Robot
{

    enum State
    {
        fight,
        adventure
    };

    private State state;

    


    protected new void Start()
    {
        base.Start();       
        state = State.fight;
    }

    
    protected new void FixedUpdate()
    {           
        float vertical = Controller.Vertical();
        float horizontal = Controller.Horizontal();
        bool up = Controller.Jump();        

        var vel = new Vector3(horizontal,entityController.vector.y,vertical);
       
        if (entityCollider.isActive(Side.right) && vel.x > 0 ||
            entityCollider.isActive(Side.left) && vel.x < 0)
        {
            vel.x = 0;
        }

        if ( (entityCollider.isActive(Side.front) && vel.z > 0) ||
            (entityCollider.isActive(Side.back) && vel.z < 0))
        {
            vel.z = 0;
        }

        

        switch (state)
        {
            case State.adventure:
                entityController.SetVelocity(vel);        
        
                if (up && !jumped)
                    StartCoroutine("Jump");           
                
                break;
        }
        

        
        base.FixedUpdate();
    }


    public void Fight()
    {

    }



}
