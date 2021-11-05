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
        moveDirection = new Vector3(1,0,1);
        Stop();
    }

   

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (path == pathType.linear)
            postPatrol();
        else if (path == pathType.area)
            areaPatrol();       
    }

    public void postPatrol()
    {
        if (patrol == patrolType.pingPong)
        {
            if (pos >= posts.Length - 1)
                direction = -1;
            else if (pos <= 0)
                direction = 1;
        }
        else if (patrol == patrolType.loop)
        {
            if (pos >= posts.Length)
                pos = 0;
        }

        Vector3 origin = transform.position;
        origin.y = 0;
        Vector3 dir = posts[pos] - origin;

        controller.SimpleMove(dir.normalized * speed);

        if (dir.magnitude < 1)
        {
            pos += direction;
        }
    }

    public void areaPatrol()
    {
        if (transform.position.x > posts[0].x)//LEFT
        {
            moveDirection.x = Random.Range(-.1f, -1) * speed;
            moveDirection.z = Random.Range(-1, 1) * speed;
            
        }
        else if (transform.position.x <= posts[1].x)//RIGHT
        {
            moveDirection.x = Random.Range(.1f, 1) * speed;
            moveDirection.z = Random.Range(-1, 1) * speed;
            
        }
        else if (transform.position.z <= posts[0].z)//TOP
        {
            moveDirection.x = Random.Range(-1, 1) * speed;
            moveDirection.z = Random.Range(.1f, 1) * speed;
            
        }
        else if (transform.position.z >= posts[1].z)//BOTTOM
        {
            moveDirection.x = Random.Range(-1, 1) * speed;
            moveDirection.z = Random.Range(-.1f, -1) * speed;
            
        }

        else if (moveDirection.x == 0 && moveDirection.z == 0)
        {

            moveDirection.x = Random.Range(-1, 1) * speed;
            moveDirection.z = Random.Range(-.1f, -1) * speed;
        }


        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
        moveDirection = moveDirection.normalized;
        
        controller.Move(moveDirection * speed * Time.deltaTime);
    }
}
