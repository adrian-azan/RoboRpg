using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Utilities;
public class Robot : Entity
{
    // Start is called before the first frame update

    /***Physics***/
    protected bool jumped;

    /***Body***/
    private bool facing;

    public float turnSpeed = 640;    
    SpriteRenderer sp;

    /***MISC***/
    public Dialogue dialogue;


    protected new void Start()
    {
        base.Start();
        dialogue = transform.GetComponentInChildren<Dialogue>();
        sp  = GetComponent<SpriteRenderer>();        
          
    }

    protected new void Update()
    {
        base.Gravity();
        turn();
        turnCheck();   
        base.Move();
    }
       

    /*
     * Checks which direction robot is moving to turn
     */
    public void turnCheck()
    {
        if (vector.x < 0)
            facing = false;
        
        else if (vector.x > 0)
            facing = true;        
    }

    
    public void turn()
    {       
        Vector3 rotation = transform.eulerAngles;
        
        if (facing == true)
        {
            
            if ((rotation.y >= 270 && rotation.y < 360) || (rotation.y >= -5 && rotation.y < 5))
                rotation.y = 0;           
            else
                rotation.y -= Mathf.Round(turnSpeed * Time.deltaTime);            
        }

        else
        {
            if (rotation.y >= 180 && rotation.y < 270)
                rotation.y = 180;            
            else
                rotation.y += Mathf.Round(turnSpeed * Time.deltaTime);
        }
       
        transform.eulerAngles = rotation;

    }


    public IEnumerator Jump()
    {
        int count = 0;

        jumped = true;
        vector.y = 2f;
        Debug.Log(count ++);
        yield return new WaitUntil(() => vector.y < 0);
        jumped = false;

    }
    
   


    
}


