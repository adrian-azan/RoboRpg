using System.Collections.Generic;
using UnityEngine;
using Abstraction.Collider;

[RequireComponent(typeof(BoxCollider))]
[System.Serializable]
public class EntityCollider
{  
    public class EntityRay
    {
        public Vector3 direction {get; }
        public Vector3 centerOffset {get; }
        public Color color {get; }
        public float length {get;set; }        
        public bool hit;
        public EntityRay(Vector3 d,Vector3 o, float l, Color c)
        {
            direction = d;
            length = l;
            centerOffset = o;
            color = c;
            hit = false;
        }

        public EntityRay(Vector3 d,float l, Color c):this(d,Vector3.zero,l,c)
        {      
        }       
    }

    [SerializeField]
    private BoxCollider bc;

    private Dictionary<Side,EntityRay> sides;   
    private Vector3 center; 

    public void FixedUpdate(Transform transform)
    {
        int environment = ~(1 << 3);


        center =  bc.transform.position;   
        foreach (var s in sides.Values)
        {
            RaycastHit hit;
            Ray landingRay = new Ray(center+s.centerOffset, s.direction);

            if (Physics.Raycast(landingRay, out hit, s.length, environment))
                s.hit = true;        
            else 
                s.hit = false;         
        } 

                
        foreach (var s in sides.Values)
        {
            if (s.hit)
                Debug.DrawRay(center+s.centerOffset, s.direction*s.length, Color.red );            
            else 
                Debug.DrawRay(center+s.centerOffset, s.direction*s.length, s.color );            
        } 
    }

    public bool isActive(Side side)
    {
        if (side == Side.front)
            return sides[Side.front_right].hit || sides[Side.front_left].hit; 
        
        if (side == Side.back)
            return sides[Side.back_right].hit || sides[Side.back_left].hit;

        if (side == Side.bottom)
            return (sides[Side.bottom_right].hit && sides[Side.bottom_left].hit) || sides[Side.bottom].hit;

        return sides[side].hit;
    }

    public void Start()
    {   
        sides = new Dictionary<Side, EntityRay>();
        center = bc.transform.position;

        float _depth = bc.size[2];
        float _height = bc.size[1];
        float _width = bc.size[0];
        float hypo = Mathf.Sqrt(Mathf.Pow(_height/1.8f,2)+Mathf.Pow(_width/1.8f,2));

        sides.Add(Side.right,  new EntityRay(Vector3.right, (_width/1.8f),Color.cyan));
        sides.Add(Side.left, new EntityRay(Vector3.left, (_width/1.8f),Color.cyan));
        sides.Add(Side.top, new EntityRay(Vector3.up ,(_height/1.8f),Color.cyan));
        sides.Add(Side.bottom, new EntityRay(Vector3.down ,(_height/1.8f),Color.cyan));
       
        sides.Add(Side.top_left, new EntityRay(new Vector3(_width,_height,0).normalized, hypo, Color.cyan));
        sides.Add(Side.top_right, new EntityRay(new Vector3(-_width,_height,0).normalized, hypo, Color.cyan));
        sides.Add(Side.bottom_left, new EntityRay(new Vector3(_width,-_height,0).normalized, hypo, Color.cyan));
        sides.Add(Side.bottom_right, new EntityRay(new Vector3(-_width,-_height,0).normalized, hypo, Color.cyan));

        sides.Add(Side.front_left, new EntityRay(Vector3.left,new Vector3(_width/2,0,_depth),_width,Color.yellow));
        sides.Add(Side.front_right, new EntityRay(Vector3.right,new Vector3(-_width/2,0,_depth),_width,Color.yellow));
        sides.Add(Side.back_left, new EntityRay(Vector3.left,new Vector3(_width/2,0,-_depth),_width,Color.yellow));
        sides.Add(Side.back_right, new EntityRay(Vector3.right,new Vector3(-_width/2,0,-_depth),_width,Color.yellow));
        
    }


}
