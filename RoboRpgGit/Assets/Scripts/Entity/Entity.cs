using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Abstraction.Collider;
using Services.Debug;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(CharacterController))]
public class Entity : MonoBehaviour
{        
    [SerializeField]
    public EntityCollider entityCollider;
    [SerializeField]
    public EntityController entityController;

    public EntityDebugger entityDebugger;

    protected void Start()
    {
        Create();
        //Controller Ignores collisions between entities and the environment
        Physics.IgnoreLayerCollision(3,6);
        entityDebugger = JsonUtility.FromJson<EntityDebugger>("Debug.json");
    }

    public void Create()
    {
        entityCollider.Start();               
    }    

    protected void FixedUpdate()
    {
        entityCollider.FixedUpdate(transform);
        
        entityController.turn();
        entityController.Move();

        if (entityCollider.isActive(Side.bottom) == false)
            entityController.Gravity();
        else
            entityController.vector.y = 0;

        
    }
}
