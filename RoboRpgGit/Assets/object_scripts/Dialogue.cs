using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Dialogue : MonoBehaviour
{
    new Camera camera;
    Text text;
    public Robot speaker;


    string[] script;
    int index;

    public string line;
    public float speed;
    float letter;

    void Start()
    {
        camera = Camera.main;
        text = GetComponentInChildren<Text>();
        index = 0;
        letter = 0;
        script = new string[5];
        script[0] = "This is a test to see how talking works";
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 angle = Vector3.zero;
        angle.x = transform.eulerAngles.x;
        angle.y = camera.transform.eulerAngles.y;
        angle.z = transform.eulerAngles.z;
        transform.eulerAngles = angle;

        Vector3 pos = speaker.transform.position;
        pos.y += (speaker.GetComponent<CharacterController>().height );
        transform.position = pos;


        if (script[index].Length >= letter)
        {
            letter += speed;
            line = script[index].Substring(0, (int)letter);

            text.text = line;
        }
        else
        {
            
        }

    }
}
