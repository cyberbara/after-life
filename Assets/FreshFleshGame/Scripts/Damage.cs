using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            HPPlayer HP = collision.gameObject.GetComponent<HPPlayer>();
            HP.Hit(damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
