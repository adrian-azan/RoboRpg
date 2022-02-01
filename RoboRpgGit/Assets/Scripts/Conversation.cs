using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation : MonoBehaviour
{

    public string[] RobotNames;
    public Robot[] bots;
    public IDictionary<string,Robot> speakers = new Dictionary<string,Robot>();

    public TextAsset convo;
    private scriptLine[] lines;
    private int place = 0;
    bool active = false;

    private scriptParser sp = new scriptParser();
    //public GameObject activator;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < bots.Length;i++)
        {
            speakers[RobotNames[i]] = bots[i];
        }
        lines = sp.ReadScript(convo.text);
        foreach (var line in lines)
        {
            Debug.Log(line.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (active && place < lines.Length-1)
        {
            string name = lines[place].name;            
            if (speakers[name].dialogue.finished)
            {              
                StartCoroutine(progress());
            }            
        }
    }

    public IEnumerator progress()
    {
        string name = lines[place].name;
        speakers[name].dialogue.finished = false;
        yield return new WaitForSeconds(2);

        place++;
        if (place < lines.Length)
        {
            name = lines[place].name;
            string line = lines[place].line;
            speakers[name].dialogue.SetLine(line);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other == null || active) return;

       // if (other.CompareTag("player"))
       // {           
       //     active = true;
                        
      //  }

    }
}
