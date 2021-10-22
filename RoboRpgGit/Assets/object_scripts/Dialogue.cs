using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Dialogue : MonoBehaviour
{
    new Camera camera;
    Text text;
    SpriteRenderer sprite;
    public Robot speaker;


    string script;

    public string line;
    public float speed;
    float letter;
    public bool finished;

    void Start()
    {
        camera = Camera.main;
        text = GetComponentInChildren<Text>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        letter = 0;
        script = "";       
        finished = true;
    }

   

    // Update is called once per frame
    void Update()
    {
        SetPosition();
        if (script.Length > letter)
        {
            letter += speed;
            line = script.Substring(0, (int)letter);
            text.text = line;
            
        }
        else
        {
            finished = true;            
        }
    }

    public void SetPosition()
    {
        Vector3 angle = Vector3.zero;
        angle.x = transform.eulerAngles.x;
        angle.y = camera.transform.eulerAngles.y;
        angle.z = transform.eulerAngles.z;
        transform.eulerAngles = angle;

        Vector3 pos = speaker.transform.position;
        pos.y += (speaker.GetComponent<CharacterController>().height);
        transform.position = pos;
    }

    public void SetLine(string line)
    {
        script = line;
        letter = 0;
        finished = false;

        Color color = sprite.color;
        Color textColor = text.color;
        color.a = 1;
        textColor.a = 1;
        sprite.color = color;
        text.color = textColor;
    }
    

    public IEnumerator startFade(float delay, float rate)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(fade(rate));
    }

    public IEnumerator fade(float rate)
    {
        Color color = sprite.color;
        Color textColor = text.color;
        if ((color.a >= 0 || color.a <= 1) && finished)
        {
            color.a += rate;
            textColor.a += rate;
            sprite.color = color;
            text.color = textColor;

            yield return new WaitForSeconds(.2f);
            StartCoroutine(fade(rate));
        }
    }
}
