using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Robot[] enemies;
    public Robot[] allies;
    public MenuSystem ms;

    public int index;

    void Start()
    {
        ms = GetComponentInChildren<MenuSystem>();
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        index += Input.GetKeyDown("r") ? 1 : 0;
        index %= allies.Length;
        ms.setPos(allies[index]);
    }




    public void setEnemies(Robot[] e)
    {
        enemies = (Robot[])e.Clone();
    }
    public void setAllies(Robot[] a)
    {
        allies = (Robot[])a.Clone();
    }
}
