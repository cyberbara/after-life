using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsSwitch : MonoBehaviour
{
    public static int Weapons = 0;
    public static int WeaponOypen = 5;
    public static bool ShootGun = false;
    public static bool Ak = false;
    public static bool pistol = false;
    public static bool book = false;


    void Start()
    {
        SelectWeapons();
    }

    void Update()
    {

        int currentWeapon = Weapons;



        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (Weapons >= transform.childCount - WeaponOypen)
            {
                Weapons = 0;
            }
            else
            {
                Weapons++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (Weapons <= 0)
            {
                Weapons = transform.childCount - WeaponOypen;
            }
            else
            {
                Weapons--;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Weapons = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)&& pistol == true)
        {
            Weapons = 1;
        }

        

        if (Input.GetKeyDown(KeyCode.Alpha3) && ShootGun == true)
        {
            Weapons = 2;
        }


        if (Input.GetKeyDown(KeyCode.Alpha4) && Ak == true)
        {
            Weapons = 3;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) && book == true)
        {
            Weapons = 4;
        }

        if (currentWeapon != Weapons)
        {
            SelectWeapons();
        }
    }





    void SelectWeapons()
    {
        int i = 0;

        foreach (Transform weapons in transform)
        {
            if (i == Weapons)
                weapons.gameObject.SetActive(true);
            else
                weapons.gameObject.SetActive(false);

            i++;
        }
    }
}
