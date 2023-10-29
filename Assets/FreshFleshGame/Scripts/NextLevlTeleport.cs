using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[AddComponentMenu ("My components/Teleport")]
public class NextLevlTeleport : MonoBehaviour
{
    public int GoodSceneIndex;
    public int BedSceneIndex;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {

        }
    }
}
