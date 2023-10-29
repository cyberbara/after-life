using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusikTrigger : MonoBehaviour
{
    public GameObject asctiv;
    public GameObject noActive;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            asctiv.SetActive(true);
            noActive.SetActive(false);

            Destroy(gameObject);
        }
    }
}
