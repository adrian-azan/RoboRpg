using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] options;
    public GameObject center;
    private Vector3 rotation;
    

    //Menu Controls
    private int speed = 5;
    private float count = 90;
    private int direction;
    bool rotating;

    void Start()
    {
        options = GameObject.FindGameObjectsWithTag("option");
        center = GameObject.FindGameObjectWithTag("center");
        rotating = false;
    }

    // Update is called once per frame
    void Update()
    {
        turnCheck();             
    }

    public void turnCheck()
    {
        float back = Input.GetKey("q") ? -1 : 0;
        float next = Input.GetKey("e") ? 1 : 0;

        if (rotating == false && next == 1)
        {
            direction = 1;
            StartCoroutine(turnStart());
        }

        else if (rotating == false && back == -1)
        {
            direction = -1;
            StartCoroutine(turnStart());
        }

   
    }

    public IEnumerator turnStart()
    {
        
        count = 120;
        rotating = true;
        yield return new WaitUntil(turn);
        rotating = false;

    }

    public bool turn()
    {
        count -= speed;
        rotation.y += speed*direction;
        transform.eulerAngles = rotation;
        return count <= 0;
    }
   
}
