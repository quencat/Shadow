using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour
{
    UnityEngine.Object[] matList;
    Material[] mats = new Material[17];
    int curr = 0;
    float[] timeToChange = {10, 5, 5, 20, 5, 10, 10, 20, 5, 20, 5, 10, 15, 15, 5, 20, 20};

    // Start is called before the first frame update
    void Start()
    {
        
        matList = Resources.LoadAll("Material", typeof(Material));
        Array.Sort(matList, delegate (UnityEngine.Object x, UnityEngine.Object y) { return int.Parse(x.name).CompareTo(int.Parse(y.name)); });

        for (int i = 0; i < matList.Length; i ++)
        {
            mats[i] = matList[i] as Material;
        }
        GetComponent<SkinnedMeshRenderer>().material = mats[0];
        StartCoroutine("autoChange");
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator autoChange()
    {
        while (true)
        {
            //
            GetComponent<SkinnedMeshRenderer>().material = mats[curr];
            yield return new WaitForSeconds(timeToChange[curr]);
            yield return new WaitForSeconds(1);
            curr++;
            if (curr >= mats.Length)
            {
                curr = 0;
            }
        }
    }
}
