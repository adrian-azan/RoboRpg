using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Utilities;
using Abstraction.Collider;
public class Robot : Entity
{
    // Start is called before the first frame update

    /***Physics***/
    protected bool jumped;

    /***Body***/
  
    SpriteRenderer sp;

    /***MISC***/
    public Dialogue dialogue;

    

    protected new void Start()
    {
        base.Start();
        dialogue = transform.GetComponentInChildren<Dialogue>();
        sp  = GetComponent<SpriteRenderer>();        
          
    }

    protected void Update()
    {
    
    }
       
    protected new void FixedUpdate()
    {     
        base.FixedUpdate();
    }

    public IEnumerator Jump()
    {
        jumped = true;
        entityController.vector.y = 2f;
   
        yield return new WaitUntil(() => entityCollider.isActive(Side.bottom));
        jumped = false;

    }
    
   


    
}


