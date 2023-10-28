using UnityEngine;
using System;
using System.Collections;

public class TRIGGERspawn : MonoBehaviour
{
    public GameObject melody, mel;
    private int a = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (a == 0)
        {
            mel = Instantiate(melody);
            StartCoroutine(destroymelody());
            a++;
        }
    }
    
    IEnumerator destroymelody()
    {
        yield return new WaitForSeconds(15f);
        Destroy(mel);
        a = 0;
    }
}
