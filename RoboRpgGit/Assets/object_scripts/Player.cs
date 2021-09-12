using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PartyMember
{
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<CharacterController>() == null)
            controller = new CharacterController();
        moveDirection = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float back = Input.GetKey("w") ? -1 : 0;
        float forward = Input.GetKey("s") ? 1 : 0;
        float left = Input.GetKey("a") ? 1 : 0;
        float right = Input.GetKey("d") ? -1 : 0;
        bool up = Input.GetKeyDown("space") ? true : false;



        if (right == -1)
        {
            facing = true; turning = true;
        }
        else if (left == 1)
        {
            facing = false; turning = true;
        }

        moveDirection = new Vector3((left + right) * speed,
                                    moveDirection.y,
                                    (back + forward) * speed);

        if (up == true)
            jump();

        gravity();
        //turn();
        controller.Move(moveDirection * Time.deltaTime);

    }
}
