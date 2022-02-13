using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Abstraction.Collider;

public class Player : Robot
{
   // public Party _party;
   // public Entity test;

    protected void Awake()
    {
         /*_party = new Party(this,test,0);

        for (int i = 0; i < _party.party.Length; i++)
        {
           entityController.ignoreCollision(_party.party[i]);
            for (int j = 0; j < _party.party.Length; j++)
                _party.party[j].entityController.ignoreCollision(_party.party[i]);
        }*/
    }

    protected new void Start()
    {
        base.Start();       
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

        


        entityController.SetVelocity(vel);
        
        
        if (up && !jumped)
        {
            StartCoroutine("Jump");           
        }
        
      
        base.FixedUpdate();
        //_party.FixedUpdate();
    }

}
