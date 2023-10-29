using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ammo : MonoBehaviour
{
    public float ammo = 100;

    [SerializeField] private TextMeshProUGUI allAmmo;

    void Update()
    {
        allAmmo.text = ammo.ToString();
    }

}
