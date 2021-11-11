using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatItem
{
    string name;
    string description;

    public CombatItem() : this("NA", "NA") { }
  

    public CombatItem(string n, string d)
    {
        name = n;
        description = d;
    }
}
