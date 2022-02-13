using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EntityController
{

    private float directionAngle;

    [SerializeField]
    protected bool gravity;  
    [SerializeField]
    protected float speed;    
    [SerializeField]
    protected float acceleration;    
    protected bool facing;
    [SerializeField]
    public float turnSpeed;  
    
    [SerializeField]
    public CharacterController controller;  
    public Vector3 vector;

    public void ignoreCollision(Entity other)
    {
        Physics.IgnoreCollision(controller, other.entityController.controller, true);
    }    

    public void turn()
    {       
        Vector3 rotation = controller.transform.eulerAngles;
        if (vector.x < 0)
            facing = false;        
        else if (vector.x > 0)
            facing = true;  


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
       
        controller.transform.eulerAngles = rotation;

    }

     public void Gravity(float scale = 1)
    {
        if (gravity)
        { 
            if (vector.y >= -.2f)
                vector.y += (Physics.gravity.y * Time.fixedDeltaTime * scale);         
            else
                vector.y = (Physics.gravity.y * Time.fixedDeltaTime * scale);
        }
    }

    public void Move(float scale = 1)
    {
        controller.Move(vector);
    }

    public void SetVelocity(float scale = 1)
    {
        vector = new Vector3(1F, vector.y, 1F);
        vector.x = -vector.x * Mathf.Cos(directionAngle);
        vector.z = vector.z * Mathf.Sin(directionAngle) ;

        SetVelocity(vector,scale);
    }

    public void SetVelocity(Vector3 velocity, float scale = 1)
    {
        vector.x = velocity.x * speed * scale * Time.fixedDeltaTime;
        vector.z = velocity.z * speed * scale * Time.fixedDeltaTime;
       
    }    

    public void SetDirection(float angle)
    {
        angle = Mathf.Deg2Rad * angle;
        angle = Mathf.Round(angle * 10.0f) * 0.1f;

        directionAngle = angle;
        Debug.Log(directionAngle);
    }
    public void SetDirection(Entity target)
    {
        Vector3 targetPosition = target.transform.position;
        Vector3 directionToTarget = controller.transform.position - targetPosition;
        float angle = Vector3.SignedAngle(Vector3.left, directionToTarget, Vector3.up) + 180;

        SetDirection(angle);
    }
    public void SetDirection(Vector3 target)
    {        
        Vector3 directionToTarget = controller.transform.position - target;
        float angle = Vector3.SignedAngle(Vector3.left, directionToTarget, Vector3.up) + 180;

        SetDirection(angle);
    }
}
