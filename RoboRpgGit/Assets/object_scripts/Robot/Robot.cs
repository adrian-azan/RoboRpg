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
    public bool jumped = false;


    /***Body***/
    public bool facing { get; set; }
    public float turnSpeed = 640;
    SpriteRenderer sp;


    /***Movement***/
    public CharacterController controller;
    public Vector3 moveDirection;
    public float directionAngle;

    /***DEBUGING***/
    protected static int count = 0;
    public string ID;
    public bool DEBUG = false;


    /***MISC***/
    public Dialogue dialogue;

    /*
     * Sends raycast to feet of the robot to determine
     * if on the ground or not
     */

    protected void Start()
    {
        moveDirection = new Vector3(0, 0, 0);
        dialogue = transform.GetComponentInChildren<Dialogue>();
        sp = GetComponent<SpriteRenderer>();
    }

    protected void Update()
    {
        gravity();
        turn();
        turnCheck();
        Forward();
    }


    public void FixedUpdate()
    {

        float midToGround = GetComponent<BoxCollider>().size[1]/2;
        float distance = midToGround;
        
        RaycastHit hit;
        Ray landingRay = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * (distance), Color.blue);

        if (Physics.Raycast(landingRay, out hit, distance))
        {
            grounded = true;
            canJump = true;
        }
        else
            grounded = false;

    }

    public void gravity()
    {
        if (grounded && jumped == false)
            moveDirection.y = 0;
        else
            moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
    }

    /*
     * Checks which direction robot is moving to turn
     */
    public void turnCheck()
    {
        if (moveDirection.x < 0)
            facing = true;
        
        else if (moveDirection.x > 0)
            facing = false;        
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

    public IEnumerator jumpedReset()
    {
        yield return new WaitForSeconds(.2F);
        jumped = false;
    }
    public void jump()
    {        
        moveDirection.y = jumpSpeed;
        grounded = false;
        canJump = false;
        jumped = true;
        StartCoroutine(jumpedReset());
    }

    public void Forward(float scale = 1)
    {
        controller.Move(moveDirection * Time.deltaTime * scale);
    }

    public void Stop()
    {
        moveDirection = new Vector3(0, moveDirection.y, 0);
    }   

    public void SetVelocity(float scale = 1)
    {
        moveDirection = new Vector3(1F, moveDirection.y, 1F);
        moveDirection.x = -moveDirection.x * Mathf.Cos(directionAngle) * speed*scale;
        moveDirection.z = moveDirection.z * Mathf.Sin(directionAngle) * speed*scale;
    }

    public void SetDirection(float angle)
    {
        angle = Mathf.Deg2Rad * angle;
        angle = Mathf.Round(angle * 10.0f) * 0.1f;

        directionAngle = angle;
    }

    public void SetDirection(Robot target)
    {
        Vector3 targetPosition = target.transform.position;
        Vector3 directionToTarget = transform.position - targetPosition;
        float angle = Vector3.SignedAngle(Vector3.left, directionToTarget, Vector3.up) + 180;

        SetDirection(angle);
    }


    public float DistanceFrom(MonoBehaviour target)
    {
        Vector3 targetPosition = target.transform.position;

        //Made y 0 so that all distances are only counting the x/z plane
        targetPosition.y = 0;
        Vector3 xz = transform.position;
        xz.y = 0;
        return (targetPosition - xz).magnitude;
    }
}

