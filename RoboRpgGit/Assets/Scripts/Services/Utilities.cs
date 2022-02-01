using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Utilities
{
    public class Space
    {
       
        public static float DistanceFrom(Entity A, Entity B)
        {
            Vector3 PosB = B.transform.position;
            Vector3 PosA = A.transform.position;
             
            return (PosA - PosB).magnitude;
        }

        public static float DistanceFrom(Entity A, Vector3 B)
        {
            Vector3 PosA = A.transform.position;          
             
            return (PosA - B).magnitude;
        }

        public static float DistanceFrom(Vector3 A, Vector3 B)
        {      
            return (A - B).magnitude;
        }
    }
}
