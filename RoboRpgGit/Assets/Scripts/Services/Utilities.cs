using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Utilities
{
    public class Space
    {
       
        public static float DistanceFrom(Entity A, Entity B, float tolerance = 0)
        {
            Vector3 PosB = B.transform.position;
            Vector3 PosA = A.transform.position;
             
            return (PosA - PosB).magnitude - tolerance;
        }

        public static float DistanceFrom(Entity A, Vector3 B, float tolerance = 0)
        {
            Vector3 PosA = A.transform.position;          
             
            return (PosA - B).magnitude - tolerance;
        }

        public static float DistanceFrom(Vector3 A, Vector3 B, float tolerance = 0)
        {      
            return (A - B).magnitude - tolerance;
        }
    }
}
