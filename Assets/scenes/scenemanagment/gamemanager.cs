using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public int sceneindHell, sceneindParadise;

    public GameObject settings;
    public GameObject menu;

    public Slider SoundVol;
    public AudioSource[] Sounds = new AudioSource[0];

    public void QuitGame()
    {
        Application.Quit();
    }
    public void SettingsOn()
    {
        settings.SetActive(true);
        menu.SetActive(false);
    }

    public void SettingsOff()
    {
        settings.SetActive(false);
        menu.SetActive(true);
    }
    public void StartGameforhell()
    {
        SceneManager.LoadScene(sceneindHell);
    }
    public void StartGameforray()
    {
        SceneManager.LoadScene(sceneindParadise);
    }

    // settings

    public void Scale1600to900()
    {
        Screen.SetResolution(1600, 900, true);
    }
    public void Scale1920to1080()
    {
        Screen.SetResolution(1920, 1080, true);
    }
    public void Scale1280to720()
    {
        Screen.SetResolution(1280, 720, true);
    }

    public void SoundCheck()
    {
        float volumeset = SoundVol.value;
        Debug.Log("jflhgh");

        
        for (int i = 0; i < Sounds.Length; i ++)
        {
            Sounds[i].volume = volumeset;
        }
    }

}
