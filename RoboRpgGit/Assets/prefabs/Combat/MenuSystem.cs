using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public SubMenu[] options;   
    private Vector3 rotation;
    

    //Menu Controls
    private float speed = 5;
    private float distance;
    private int direction;
    public int index;
    bool rotating;

    void Start()
    {
        
        index = 2;
        options = FindObjectsOfType<SubMenu>();        
        rotating = false;
        rotation = new Vector3(0f,0,0f);
    }

    // Update is called once per frame
    void Update()
    {
        turnCheck();
        displayMenu();
    }

    public void displayMenu()
    {
        index %= options.Length;
        index = index < 0 ? options.Length-1 : index;
        for (int i = 0; i < options.Length;i++)
        {
            if (i == index)
                options[i].showMenu();
            
            else
                options[i].hideMenu();            
        }
    }    

    public void turnCheck()
    {
        float back = Input.GetKeyDown("q") ? -1 : 0;
        float next = Input.GetKeyDown("e") ? 1 : 0;
        
        
        if (rotating == false && next == 1)
        {
            direction = 1;
            index -= 1;
            StartCoroutine(turnStart());
        }

        else if (rotating == false && back == -1)
        {
            direction = -1;
            index += 1;
            StartCoroutine(turnStart());
        }   
    }

    public IEnumerator turnStart()
    {
        
        distance = 360/options.Length;
        rotating = true;
        yield return new WaitUntil(turn);
        rotating = false;

    }

    public bool turn()
    {
        distance -= speed;
        rotation.y = speed*direction;
        transform.eulerAngles += rotation;       
        return distance <= 0;
    }

    public void setPos(Robot target)
    {
        Vector3 tp = target.transform.position;
        Vector3 pos = new Vector3(tp.x,tp.y,tp.z);

        pos.y += target.height*.75f;
        //pos.y += 2;
        this.transform.position = pos;
    }
   
}
