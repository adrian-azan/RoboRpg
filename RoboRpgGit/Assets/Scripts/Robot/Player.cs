using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Robot
{
    public Party _party;
    public Entity test;

    protected new void Start()
    {
        base.Start();
        _party = new Party(this,test,1);

        for (int i = 0; i < _party.party.Length; i++)
        {
            Physics.IgnoreCollision(controller, _party.party[i].controller, true);
            for (int j = 0; j < _party.party.Length; j++)
                Physics.IgnoreCollision(_party.party[j].controller, _party.party[i].controller, true);
        }
    }

    
    protected new void Update()
    {
        float vertical = Controller.Vertical();
        float horizontal = Controller.Horizontal();
        bool up = Controller.Jump();

       // Debug.Log($"HORI: {horizontal}");
        
        SetVelocity(new Vector3(horizontal,vector.y,vertical));
          
        
        if (up && !jumped)
        {
            Debug.Log(gravity);
            StartCoroutine("Jump");           
        }
        
      
        base.Update();
        _party.FixedUpdate();
    }

}
