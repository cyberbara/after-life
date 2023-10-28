using UnityEngine;
using System;
using System.Collections;

public class Bells : MonoBehaviour
{

    public Animator bellbong;
    public GameObject sonud;



    public void bells()
    {
        bellbong.enabled = true;
        StartCoroutine(playsound());

    }
    public IEnumerator playsound()
    {
        yield return new WaitForSeconds(0.25f);
        Instantiate(sonud);
        StartCoroutine(animoff());
    }

    public IEnumerator animoff()
    {
        yield return new WaitForSeconds(1.0f);
        bellbong.enabled = false;
    }
    public void bellend()
    {
        Debug.Log("end");
    }
    public void bellsAcess()
    {
        Debug.Log("acess");
    }


}
