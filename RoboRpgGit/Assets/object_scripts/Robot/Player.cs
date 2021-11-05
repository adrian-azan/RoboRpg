using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Robot
{
    // Start is called before the first frame update
    public PartyMember[] party;
    protected new void Start()
    {
        base.Start();
        for (int i = 0; i < party.Length; i++)
        {
            Physics.IgnoreCollision(controller, party[i].controller, true);
            for (int j = 0; j < party.Length; j++)
                Physics.IgnoreCollision(party[j].controller, party[i].controller, true);
        }
    }



    // Update is called once per frame
    void Update()
    {
        
        float back = Input.GetKey("w") ? -1 : 0;
        float forward = Input.GetKey("s") ? 1 : 0;
        float left = Input.GetKey("a") ? 1 : 0;
        float right = Input.GetKey("d") ? -1 : 0;
        bool up = Input.GetKeyDown("space") ? true : false;
               

        moveDirection = new Vector3((left + right) * speed,
                                    moveDirection.y,
                                    (back + forward) * speed);
        
        if (up == true && canJump == true)
        {
            jump();
            StartCoroutine("partyJump");
        }

        base.Update();

        

        for (int i = 0; i < party.Length - 1; i++)
        {
            party[i].updatePosition(party[i + 1]);
        }

        party[party.Length - 1].updatePosition(this);

    }


    public IEnumerator partyJump()
    {
        for (int i = party.Length-1; i >= 0; i--)
        {
            yield return new WaitForSeconds(.2f);
            party[i].jump();
        }
    }


}
