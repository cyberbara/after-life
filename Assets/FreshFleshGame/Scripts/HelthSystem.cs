using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HelthSystem : MonoBehaviour
{
    public int HP;
    public int toGubs;
    public Animator animator;
    public bool dead;

    public GameObject effectToDead;

    private void Start()
    {
        dead = false;
    }

    void Update()
    {
        if (HP <= 0)
        {
            
        }

        if (HP < toGubs)
        {
            Destroy(gameObject);
            Instantiate(effectToDead, transform.position, Quaternion.identity);
        }
    }

    public void Hit(int damage)
    {
        HP -= damage;
    }
}
