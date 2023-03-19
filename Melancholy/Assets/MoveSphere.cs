using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveSphere : MonoBehaviour
{
    float x;
    float y;
    float z;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        x = GameObject.Find("ArdReceiver").GetComponent<ArdReceive>().getX();
        y = GameObject.Find("ArdReceiver").GetComponent<ArdReceive>().getY();
        z = GameObject.Find("ArdReceiver").GetComponent<ArdReceive>().getZ();

        double magnitude = Math.Sqrt((double)(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z , 2)));
        if (magnitude > 1000)
        {
            magnitude = 1000;
        }
        transform.localScale = (new Vector3((float)magnitude, (float)magnitude, (float)magnitude)) / 200;
        transform.position = new Vector3(makePos(x), makePos(x), makePos(z));
    }
    float makePos(float n)
    {
        if(n > 1000)
        {
            n = 1000;
        } else if (n < -1000)
        {
            n = -1000;
        }
        n = n / 200;
        return n;
    }
}
