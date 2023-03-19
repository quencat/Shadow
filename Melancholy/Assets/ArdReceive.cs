using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArdReceive : MonoBehaviour
{
    float x;
    float y;
    float z;
    SerialPort sp = new SerialPort("COM11", 115200);
    // Start is called before the first frame update
    void Start()
    {
        sp.WriteTimeout = 300;
        sp.ReadTimeout = 5000;
        sp.DtrEnable = true;
        sp.RtsEnable = true;
        sp.Open();
    }

    // Update is called once per frame
    void Update()
    {
        string v = sp.ReadLine();
        string[] line = v.Split(" ");
        if (line.Length == 3)
        {
            float.TryParse(line[0], out x);
            float.TryParse(line[1], out y);
            float.TryParse(line[2], out z);
        }
    }
    public float getX()
    {
        return x;
    }
    public float getY()
    {
        return y;
    }
    public float getZ()
    {
        return z;
    }
}
