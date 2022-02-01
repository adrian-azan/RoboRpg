using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticsMenu : SubMenu
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        content = new string[3] { "Run", "Analyze", "Defend"};
        index = 0;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();   
    }

    public override void select()
    {
        
    }
}
