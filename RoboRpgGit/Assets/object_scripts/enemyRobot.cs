using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRobot : Robot
{
    // Start is called before the first frame update
    public Vector3[] path;
    public int pos;
    private int direction;
    private Color debugColor;


    protected new void Start()
    {
        base.Start();
        direction = 1;
        pos = 0;
        debugColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < path.Length; i++)
        {
            Debug.DrawRay(path[i], transform.TransformDirection(Vector3.up) * 2, debugColor);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (pos >= path.Length-1)
            direction = -1;
        else if (pos <= 0)
            direction = 1;

        Vector3 origin = transform.position;
        origin.y = 0;
        Debug.Log(pos);
        Vector3 dir = path[pos] - origin;
        
        controller.SimpleMove(dir.normalized*speed);

        if (dir.magnitude < 1)
        {
            pos += direction;
        }
        
    }
}
