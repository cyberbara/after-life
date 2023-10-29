using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    [Header("Компаненты")]
    public GameObject bullet;
    public Transform spawnBulet;
    public AudioSource soundSorse;
    public AudioClip soundAttak;
    public Animator animator;

    [Header("Настройка выстрела")]
    public float pointOnVoid = 100;
    public float spread;
    public float buletNumder;
    private float startTimeShot;
    public float timeShot;
    public float shootforse;

    [Header("Настройка разброса")]
    public float spreadX;
    public float spreadY;
    public float spreadZ;

    [Header("Луч")]
    public float DrawRay;

    void Update()
    {
        if (startTimeShot <= 0)
        {
            startTimeShot = timeShot;
            Shoot();
        }
        else
        {
            startTimeShot -= Time.deltaTime;
            animator.SetBool("bam", false);
        }
    }

    void Shoot()
    {
        animator.SetBool("bam", true);
    }

    public void OnAtakc()
    {
        soundSorse.PlayOneShot(soundAttak);


        for (int i = 0; i < buletNumder; i++)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.forward * 100, Color.red);

            Vector3 targetPoint;

            if (Physics.Raycast(ray, out hit))
                targetPoint = ray.GetPoint(pointOnVoid);
            else
                targetPoint = ray.GetPoint(pointOnVoid);

            Vector3 dirWithoutSpread = ray.GetPoint(pointOnVoid) - spawnBulet.position;

            float x = Random.Range(-spreadX, spreadX);
            float y = Random.Range(-spreadY, spreadY);
            float z = Random.Range(-spreadZ, spreadZ);

            Vector3 dirWithSpread = dirWithoutSpread + new Vector3(x, y, z);

            GameObject currentBullet = Instantiate(bullet, spawnBulet.position, Quaternion.identity);

            currentBullet.transform.forward = dirWithoutSpread.normalized;

            currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * shootforse, ForceMode.Impulse);
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(spawnBulet.position, .4f);
        var direction = spawnBulet.TransformDirection(Vector3.forward);
        Debug.DrawRay(spawnBulet.position, transform.forward * DrawRay, Color.red);
    }
}
