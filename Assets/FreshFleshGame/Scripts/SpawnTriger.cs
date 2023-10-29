using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTriger : MonoBehaviour
{
    public GameObject asctiv;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            asctiv.SetActive(true);
            Destroy(gameObject);
        }
    }
}
