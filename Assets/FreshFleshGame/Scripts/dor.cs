using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dor : MonoBehaviour
{
    public float z;
    public float y;
    public float x;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.position = transform.position + new Vector3(x, y, z);
            print("Дверь открыта");
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
