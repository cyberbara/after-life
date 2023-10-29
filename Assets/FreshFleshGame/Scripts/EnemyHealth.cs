using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public int HP;
    public Animator animator;

    void Update()
    {
        if (HP <= 0)
        {
            animator.SetBool("ded", true);

        }
    }

    public void Hit(int damage)
    {
        HP -= damage;
    }
}
