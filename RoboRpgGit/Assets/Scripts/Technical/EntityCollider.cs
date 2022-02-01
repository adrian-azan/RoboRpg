using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCollider
{  
    private class EntityRay
    {
        public Vector3 direction{get; }
        public Color color{get;set; }
        public float length { get;set;}
        public EntityRay(Vector3 d,float l, Color c)
        {
            direction = d;
            length = l;
            color = c;
        }
    }

    private Dictionary<string,EntityRay> sides;
    private BoxCollider bc;
    private Vector3 center;
    
 

    public void FixedUpdate(Transform transform)
    {
        center =  bc.transform.position;
        
        foreach (var s in sides.Values)
        {
            RaycastHit hit;
            Ray landingRay = new Ray(center, s.direction);

            if (Physics.Raycast(landingRay, out hit, s.length))
                Debug.DrawRay(center, s.direction*s.length, Color.red );            
            else 
                Debug.DrawRay(center, s.direction*s.length, s.color );            
        } 
    }

    // Start is called before the first frame update
    public EntityCollider(BoxCollider boxCollider)
    {
       

        sides = new Dictionary<string, EntityRay>();
        bc = boxCollider;
        center = bc.transform.position + bc.center;
        float _height = bc.size[1];
        float _width = bc.size[0];
         float hypo = Mathf.Sqrt(Mathf.Pow(_height/1.8f,2)+Mathf.Pow(_width/1.8f,2));

        sides.Add("right",  new EntityRay(Vector3.right, (_width/1.8f),Color.cyan));
        sides.Add("left", new EntityRay(Vector3.left, (_width/1.8f),Color.cyan));
        sides.Add("up", new EntityRay(Vector3.up ,(_height/1.8f),Color.cyan));
        sides.Add("down", new EntityRay(Vector3.down ,(_height/1.8f),Color.cyan));
       
        sides.Add("top-left", new EntityRay(new Vector3(_width,_height,0).normalized, hypo, Color.cyan));
        sides.Add("top-right", new EntityRay(new Vector3(-_width,_height,0).normalized, hypo, Color.cyan));
        sides.Add("bottom-left", new EntityRay(new Vector3(_width,-_height,0).normalized, hypo, Color.cyan));
        sides.Add("bottom-right", new EntityRay(new Vector3(-_width,-_height,0).normalized, hypo, Color.cyan));
    }


}
