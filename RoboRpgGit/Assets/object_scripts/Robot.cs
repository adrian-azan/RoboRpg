using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Robot : MonoBehaviour
{
    // Start is called before the first frame update

    /***Physics***/
    public float speed = 12;
    public float jumpSpeed = 50;
    public float gravityScale = .12F;
    public bool grounded = true;
    public bool canJump = true;


    /***Body***/
    public bool turning { get; set; }
    public bool facing { get; set; }
    public float turnSpeed = 640;

    /***Movement***/
    public CharacterController controller;
    public Vector3 moveDirection;

    /***DEBUGING***/
    protected static int count = 0;
    public string ID;
    public bool DEBUG = false;


    /***MISC***/


    protected void Start()
    {  
        moveDirection = new Vector3(0, 0, 0);    
    }

    // Update is called once per frame
    void Update()
    {
        gravity();
        controller.Move(moveDirection);
    }
    

    public void turn()
    {
        Vector3 rotation = transform.eulerAngles;
        if (!turning)
        {
            return;
        }

        if (facing == true)
        {

            if ((rotation.y >= 270 && rotation.y < 360) || (rotation.y >= -5 && rotation.y < 5))
            {
                rotation.y = 0;
                turning = false;
            }
            else
                rotation.y -= Mathf.Round(turnSpeed * Time.deltaTime);

        }

        else
        {
            if (rotation.y >= 180 && rotation.y < 270)
            {
                rotation.y = 180;
                turning = false;
            }
            else
                rotation.y += Mathf.Round(turnSpeed * Time.deltaTime);
        }

        transform.eulerAngles = rotation;
    }

    public void jump()
    {
        
        moveDirection.y = jumpSpeed;
        grounded = false;  
        canJump = false;
    }

    public void gravity()
    {
        if (grounded)
        {
            moveDirection.y = 0;
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
    }

}
