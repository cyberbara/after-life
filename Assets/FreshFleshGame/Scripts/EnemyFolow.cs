using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyFolow : MonoBehaviour
{
    public AudioSource soundSorse;
    public Transform AttackPoint;
    public AudioClip sound;
    public Animator animator;
    private NavMeshAgent agent = null;
    public Transform target;


    [Header("ספונא")]
    public LayerMask player;
    public float raduis;
    public float raduis2;
    public Transform centre;



    void Update()
    {
        if (Physics.CheckSphere(centre.position, raduis, player))
        {
            walkOnPlfyer();
        }

        if (Physics.CheckSphere(centre.position, raduis2, player))
        {
            attackOnPlayer();
        }

        AttackPoint.transform.LookAt(target.position);

    }

    private void MoveOnTarget()
    {
        agent.SetDestination(target.position);
    }

    private void Start()
    {
        GetReferense();
    }

    private void GetReferense()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(centre.position, raduis);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(centre.position, raduis2);
    }


    public void soundDD()
    {
        soundSorse.PlayOneShot(sound);
    }

    void walkOnPlfyer()
    {
        MoveOnTarget();
        animator.SetBool("bam", false);
        animator.SetBool("move",true);
        GetComponent<EnemyAttack>().enabled = false;    
    }

    void attackOnPlayer()
    {
        animator.SetBool("bam", true);
        GetComponent<EnemyAttack>().enabled = true;
    }
}
