using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatMenu : SubMenu
{



    // Start is called before the first frame update
    void Start()
    {
        base.Start();      
        content = new string[5] { "BodySlam", "QuickRush", "BitSkip", "Overflow", "underFlow" };       
        index = 0;
    }



    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public override void select()
    {
        
    }


}
