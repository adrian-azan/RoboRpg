using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public float xDistance;
    public float yDistance;
    public float zDistance;

    public float xRotation;
    public float yRotation;
    public float zRotation;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = target.transform.position;
        transform.position = new Vector3(p.x + xDistance,
                                         p.y + yDistance,
                                         p.z + zDistance);

        transform.eulerAngles = new Vector3(xRotation, yRotation, zRotation);
    }
}
