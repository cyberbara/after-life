using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CatAim : MonoBehaviour
{
    private float startTimeAim;
    private float timeAim;
    public float random1;
    public float random2;
    public float min;

    void Update()
    {
        timeAim = Random.Range(random1, random2);

        if (startTimeAim <= min)
        {
            GetComponent<EnemyFolow>().raduis2 = 62;
            startTimeAim = timeAim;
        }
        else
        {
            GetComponent<EnemyFolow>().raduis2 = 3;
            startTimeAim -= Time.deltaTime;
        }
    }
}
