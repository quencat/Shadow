using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeHeight : MonoBehaviour
{
    float r;
    float s;
    // Start is called before the first frame update
    void Start()
    {
        r = Random.Range(0, 1.0f);
        s = Random.Range(-1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.unscaledTime + r, 0.5f)* 0.2f - 0.2f, transform.position.z);
    }

    IEnumerator countCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);
        r = Random.Range(-1.0f, 1.0f);

    }
}
