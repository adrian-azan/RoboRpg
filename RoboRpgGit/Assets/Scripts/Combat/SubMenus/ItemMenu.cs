using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMenu : SubMenu
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        content = new string[5] { "Extra Chip", "Nearby Screw", "Screen Protector", "Oil", "A fat blunt" };
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
