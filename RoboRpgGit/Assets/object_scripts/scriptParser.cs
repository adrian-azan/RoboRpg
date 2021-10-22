using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct scriptLine
{
    public string name;
    public string line;

    override
    public string ToString()
    {
        return name + ": " + line;
    }
}

public class scriptParser 
{
    char seperator = ',';
    const int COLUMNS = 2;
   
    public scriptLine[] ReadScript(string text)
    {

        string[] lines = text.Split('\n');
        scriptLine[] script = new scriptLine[lines.Length];
        for (int i = 0; i < lines.Length;i++)
        {
            string[] dialogueParts = lines[i].Split('^');
            if (dialogueParts.Length == COLUMNS)
            {              
                script[i].name = dialogueParts[0];
                script[i].line = dialogueParts[1];
            }
        }


        return script;
    }



    public int getSize(string text)
    {
        int size = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == '\n')
                size++;
        }
        return size;
    }
}
