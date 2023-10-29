using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PayseMeny : MonoBehaviour
{
    public Slider slider;
    public bool PauseGame;
    public GameObject PayseGameMenu;




    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
            {
                Resume();
            }
            else
            {
                Payse();
            }
        }
    }


    public void Resume()
    {
        PayseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    

    public void Payse()
    {
        PayseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMeny");
    }

    public void Sensity()
    {
        CameraLook.mousesentifity = slider.value;
    }

}
