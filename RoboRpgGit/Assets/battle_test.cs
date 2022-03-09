using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battle_test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var temp = transform.localRotation.eulerAngles;
        temp.y += 1;
        transform.eulerAngles = temp;
    }
}
