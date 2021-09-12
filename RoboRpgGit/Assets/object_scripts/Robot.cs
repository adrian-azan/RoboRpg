using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    // Start is called before the first frame update

    /***Physics***/
    public float speed = 12;
    public float jumpSpeed = 50;
    public float gravityScale = .1F;
    public bool grounded = true;


    /***Body***/
    public bool turning { get; set; }
    public bool facing { get; set; }
    public float turnSpeed = 640;

    /***Movement***/
    public CharacterController controller;
    public Vector3 moveDirection;



    void Start()
    {
        if (GetComponent<CharacterController>() == null)
            controller = new CharacterController();
        moveDirection = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void jump()
    {
        moveDirection.y = jumpSpeed;
        grounded = false;
    }

    public void gravity()
    {
        if (grounded)
        {
            moveDirection.y = (Physics.gravity.y * gravityScale);
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
    }

}
