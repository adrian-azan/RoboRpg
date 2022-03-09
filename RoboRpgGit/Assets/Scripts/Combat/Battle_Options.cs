using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Options : MonoBehaviour
{
    enum State
    {
        moving,
        stable
    };


    //Should be a divisor of 120
    private float speed = 8;
    private State state;


    public void Start()
    {
        state = State.stable;
     
    }

    public IEnumerator NextOption()
    {
        if (state == State.moving) 
            yield break;

        var angle = transform.eulerAngles;
        var target = angle;
        target.y += 120;

        state = State.moving;

        while (!angle.Equals(target))
        {
            yield return new WaitForEndOfFrame();
            angle.y += speed;    
            transform.eulerAngles = angle;
        }        

        state = State.stable;
    }  

      public IEnumerator PrevOption()
    {
        if (state == State.moving) 
            yield break;

         var angle = transform.eulerAngles;
        var target = angle;
        target.y -= 120;

        state = State.moving;

        while (!angle.Equals(target))
        {
            yield return new WaitForEndOfFrame();
            angle.y -= speed;    
            transform.eulerAngles = angle;
        }    

        
        state = State.stable;
    }

}
