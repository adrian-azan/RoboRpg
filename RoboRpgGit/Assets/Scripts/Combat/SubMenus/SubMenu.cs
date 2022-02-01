using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SubMenu : MonoBehaviour
{

    public Canvas canvas;
    public Text text;

    protected string[] content;
    protected int index;
    // Start is called before the first frame update
    public void Start()
    {
        text = GetComponentInChildren<Text>();
        canvas = GetComponentInChildren<Canvas>();
        content = new string[1];
    }

   

    // Update is called once per frame
    public void Update()
    {
        int back = Input.GetKeyDown("w") ? -1 : 0;
        int forward = Input.GetKeyDown("s") ? 1 : 0;

        index += back + forward;
        index %= content.Length;
        index = index < 0 ? content.Length - 1 : index;
   
        text.text = "";
        for (int i = 0; i < content.Length; i++)
        {
            text.text += content[i];
            if (index == i) text.text += "<---\n";
            else text.text += "\n";
        }
        
    }


    public void hideMenu()
    {
        text.CrossFadeAlpha(0, .1f, true);
        Color canvasColor = canvas.GetComponent<SpriteRenderer>().color;
        canvasColor.a = 0;
        canvas.GetComponent<SpriteRenderer>().color = canvasColor;

    }

    public void showMenu()
    {
        text.CrossFadeAlpha(1, .1f, true);
        Color canvasColor = canvas.GetComponent<SpriteRenderer>().color;
        canvasColor.a = 1;
        canvas.GetComponent<SpriteRenderer>().color = canvasColor;
    }

    public abstract void select();
}
