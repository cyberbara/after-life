using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPikUp : MonoBehaviour
{
    public float ammoGive;
    public GameObject gun;

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            gun.GetComponent<Ammo>().ammo += ammoGive;
            Destroy(gameObject);
        }
    }
}
