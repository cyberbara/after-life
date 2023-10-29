using UnityEngine;
using System;
using System.Collections;

public class Bells : MonoBehaviour
{

    public Animator bellbong, bridge, bell;
    public GameObject sonud, bridgesonud;
    



    public void bells()
    {
        bellbong.enabled = true;
        StartCoroutine(playsound());
        bell.enabled = true;
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
        bell.enabled = false;
    }
    public void bellend()
    {
        Debug.Log("end");
    }
    public void bellsAcess()
    {
        bridge.enabled = true;
        Instantiate(bridgesonud);
    }


}
