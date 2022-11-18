using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void Start() {
        int scene = SceneManager.GetActiveScene().buildIndex;
        if (scene == 2) AudioManager.instance.PlaySound("Victory");
        if (scene == 3) AudioManager.instance.PlaySound("GameOver");
    }


    public void PlayButton() {
        AudioManager.instance.PlaySound("Button");
        SceneManager.LoadScene(1);
    }
    
    public void QuitButton() {
        AudioManager.instance.PlaySound("Button");
        Application.Quit();
    }
}
