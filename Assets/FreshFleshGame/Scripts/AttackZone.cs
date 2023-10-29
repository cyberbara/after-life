using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class AttackZone : MonoBehaviour
{
    public Animator animator;
    [Header("ספונא")]
    public LayerMask player;
    public float raduis;
    public Transform centre;

    private void Update()
    {

        Collider[] Player = Physics.OverlapSphere(centre.position, raduis, player);
        for (int i = 0; i < Player.Length; i++)
        {
            animator.SetBool("move", false);
            animator.SetBool("bam", true);
            GetComponent<EnemyAttack>().enabled = true;
            break;
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(centre.position, raduis);
    }
}
