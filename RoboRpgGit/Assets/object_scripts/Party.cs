using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party
{
    // Start is called before the first frame update
    public PartyMember [] party;


    public Party()
    {
        for (int i = 0; i < party.Length-1; i++)
        {
            party[i].updatePosition(party[i+1]);
        }
    }
}
