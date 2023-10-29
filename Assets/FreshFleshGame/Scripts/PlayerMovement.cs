using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheak;
    public LayerMask groundMask;
    public float speed;
    public float gravity = -9.8f;
    public float groundDistanse = 0.4f;
    public float jumpHeight = 3f;
    public AudioSource SorseSound;
    public AudioClip soundAmmo;
    public AudioClip soundHeal;
    public AudioClip soundKey;


    Vector3 velocity;

    bool isGrounded;

    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheak.position, groundDistanse, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.F10))
        {
            ReastartLevel();
        }


    }

    void ReastartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Teleport(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        Physics.SyncTransforms();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("heal"))
        {
            SorseSound.PlayOneShot(soundHeal);
        }

        if (other.CompareTag("Ammo"))
        {
            SorseSound.PlayOneShot(soundAmmo);
        }

        if (other.CompareTag("Key"))
        {
            SorseSound.PlayOneShot(soundKey);
        }

        if (other.CompareTag("AK"))
        {
            WeaponsSwitch.WeaponOypen -= 1;
            WeaponsSwitch.Ak = true;
            SorseSound.PlayOneShot(soundAmmo);
            Destroy(other.gameObject);

        }

        if (other.CompareTag("Shootgun"))
        {
            WeaponsSwitch.WeaponOypen -= 1;
            WeaponsSwitch.ShootGun = true;
            SorseSound.PlayOneShot(soundAmmo);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("pistol"))
        {
            WeaponsSwitch.WeaponOypen -= 1;
            WeaponsSwitch.pistol = true;
            SorseSound.PlayOneShot(soundAmmo);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("book"))
        {
            WeaponsSwitch.WeaponOypen -= 1;
            WeaponsSwitch.book = true;
            SorseSound.PlayOneShot(soundAmmo);
            Destroy(other.gameObject);
        }
    }
}
