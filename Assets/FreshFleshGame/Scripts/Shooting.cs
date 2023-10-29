using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{
    [Header("Компаненты")]
    public GameObject hund;
    public GameObject bullet;
    public Transform spawnBulet;
    public ParticleSystem flashh;
    public Camera cameras;
    public ParticleSystem chasing;
    public Animator animator;
    public AudioClip _soundShoot;
    public AudioSource soundShoot;

    [Header("Настройка выстрела")]
    public float pointOnVoid = 100;
    public float buletNumder;
    private float startTimeShot;
    public float timeShot;
    public float shootforse;
    public float needBulet;

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
            hund.GetComponent<WeaponsSwitch>().enabled = true;
            if (Input.GetButton("Fire1") && GetComponent<Ammo>().ammo > 0)
            {
                startTimeShot = timeShot;
                Shoot();
                hund.GetComponent<WeaponsSwitch>().enabled = false;

            }
        }
        else
        {
            startTimeShot -= Time.deltaTime;
            animator.SetBool("shoot", false);
        }

    }

    void Shoot()
    {
        animator.SetBool("shoot", true);

    }

    public void OnAtakc()
    {
        soundShoot.PlayOneShot(_soundShoot);
        GetComponent<Ammo>().ammo -= needBulet;

        for (int i = 0; i < buletNumder; i++)
        {
            Ray ray = cameras.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.forward * 100, Color.blue);

            Vector3 targetPoint;

            flashh.Play();
            chasing.Play();

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
