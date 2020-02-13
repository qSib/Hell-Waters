using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public GameObject playButton;
    public GameObject quitButton;
    public GameObject optionsButton;
    public GameObject optionsMenu;
    public GameObject exitOptionsMenu;
    public GameObject vrOn;
    public GameObject vrOff;
    public Text vrOnText;
    public Text vrOffText;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (OptionsKeeper.instance.vrEnabled == false)
        {
            vrOnText.color = new Color(1f, 1f, 1f, 0.1f);
            vrOffText.color = new Color(1f, 1f, 1f, 1f);
        }

        if (OptionsKeeper.instance.vrEnabled == true)
        {
            vrOnText.color = new Color(1f, 1f, 1f, 1f);
            vrOffText.color = new Color(1f, 1f, 1f, 0.1f);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Cage");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Options()
    {
        playButton.SetActive(false);
        quitButton.SetActive(false);
        optionsButton.SetActive(false);
        optionsMenu.SetActive(true);

    }

    public void ExitOptions()
    {
        playButton.SetActive(true);
        quitButton.SetActive(true);
        optionsButton.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void EnableVR()
    {
        OptionsKeeper.instance.vrEnabled = true;
    }

    public void DisableVR()
    {
        OptionsKeeper.instance.vrEnabled = false;
    }
}
