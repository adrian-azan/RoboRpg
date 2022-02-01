using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum patrolType
{
    pingPong,
    loop,
    none
};

public enum pathType
{
    linear,
    area,
    none
};

public class enemyRobot : Robot
{
  
    // Start is called before the first frame update
    public Vector3[] posts;
    public int pos;

    public patrolType patrol;
    public pathType path;

    private int direction;
    private Color debugColor;




    protected new void Start()
    {
        base.Start();
        direction = 1;
        pos = 0;
        debugColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);    
    }

   

    // Update is called once per frame
   

    public void postPatrol()
    {
      
    }

    public void areaPatrol()
    {
        
    }
}
