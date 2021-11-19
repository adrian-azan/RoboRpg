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
    protected new void Update()
    {
        float vertical = Controller.Vertical();
        float horizontal = Controller.Horizontal();
        bool up = Controller.Jump();

        moveDirection = new Vector3(horizontal * speed,
                                    moveDirection.y,
                                    vertical * speed);
        
        if (up == true && canJump == true)
        {
            jump();
            StartCoroutine("partyJump");
        }

        for (int i = 0; i < party.Length - 1; i++)
            party[i].updatePosition(party[i + 1]);
        

        if (party.Length >= 1)
            party[party.Length - 1].updatePosition(this);

        base.Update();  
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
