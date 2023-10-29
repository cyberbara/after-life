using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HPPlayer : MonoBehaviour
{
    public static float HP = 100;
    public TextMeshProUGUI playerHP;
    public Animator animator;
    public GameObject Image;
    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;
    public GameObject Image4;

    private void Start()
    {
        HP = 100;
        Image.SetActive(true);
        Image1.SetActive(false);
        Image2.SetActive(false);
        Image3.SetActive(false);
        Image4.SetActive(false);
    }

    public void Update()
    {
        playerHP.text = "" + HP;


        if (HP >= 30)
        {
            Image.SetActive(false);
            Image1.SetActive(false);
            Image2.SetActive(false);
            Image3.SetActive(true);
            Image4.SetActive(false);
        }

        if (HP >= 50)
        {
            Image.SetActive(false);
            Image1.SetActive(false);
            Image2.SetActive(true);
            Image3.SetActive(false);
            Image4.SetActive(false);
        }


        if (HP >= 70)
        {
            Image.SetActive(false);
            Image1.SetActive(true);
            Image2.SetActive(false);
            Image3.SetActive(false);
            Image4.SetActive(false);
        }

        if (HP >= 100)
        {
            Image.SetActive(true);
            Image1.SetActive(false);
            Image2.SetActive(false);
            Image3.SetActive(false);
            Image4.SetActive(false);
        }

    }

    public void Hit(int damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            WeaponsSwitch.WeaponOypen = 5;
            WeaponsSwitch.Weapons = 0;
            WeaponsSwitch.pistol = false;
            WeaponsSwitch.ShootGun = false;
            WeaponsSwitch.Ak = false;
            WeaponsSwitch.book = false;

            animator.SetBool("dead", true);

            print("Герой умер");
            Image.SetActive(false);
            Image1.SetActive(false);
            Image2.SetActive(false);
            Image3.SetActive(false);
            Image4.SetActive(true);
        }
    }

    public void agen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
