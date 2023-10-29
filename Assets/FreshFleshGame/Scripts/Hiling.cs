using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiling : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        print("есть контакт");

        if (other.CompareTag("Player") && other.TryGetComponent<PlayerMovement>(out var Gold))
        {
            HPPlayer.HP += 20;
            Destroy(gameObject);
        }

    }
}
