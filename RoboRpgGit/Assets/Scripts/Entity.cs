using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    /*DEBUGIN*/
    private bool DEBUG = false;
    private string ID;

    /*Physics*/
    private float directionAngle;

    [SerializeField]
    protected bool gravity;

    [SerializeField]
    protected float speed;

    [SerializeField]
    protected float acceleration;
    
    [SerializeField]
    public CharacterController controller;    
    
    [HideInInspector]
    protected Vector3 vector;
    

    protected EntityCollider entityCollider;

    protected void Start()
    {
        Create();
    }

    public void Create()
    {
        entityCollider = new EntityCollider(GetComponent<BoxCollider>());
        controller = GetComponent<CharacterController>();  
        gravity = true;
    }    

    protected void FixedUpdate()
    {
        entityCollider.FixedUpdate(transform);
    }

    protected void Update()
    {
       
    }

    public void Gravity(float scale = 1)
    {
        if (vector.y > -.2f)
            vector.y += (Physics.gravity.y * Time.fixedDeltaTime * scale);         
        else
            vector.y = (Physics.gravity.y * Time.fixedDeltaTime * scale);
    }
    public void Move(float scale = 1)
    {
        controller.Move(vector);
       // Debug.Log(vector);
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
    }

    public void SetDirection(Entity target)
    {
        Vector3 targetPosition = target.transform.position;
        Vector3 directionToTarget = transform.position - targetPosition;
        float angle = Vector3.SignedAngle(Vector3.left, directionToTarget, Vector3.up) + 180;

        SetDirection(angle);
    }

    public void SetDirection(Vector3 target)
    {        
        Vector3 directionToTarget = transform.position - target;
        float angle = Vector3.SignedAngle(Vector3.left, directionToTarget, Vector3.up) + 180;

        SetDirection(angle);
    }

}
