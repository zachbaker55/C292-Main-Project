using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    private void Awake() { 
        //Singleton.
        if (GameManager.instance != null) {
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState; 
        DontDestroyOnLoad(gameObject);
    }
    
    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //References
    public PlayerController player;

    //Logic
    public int credits;
    public int player0xp;


    //Save and Load
    public void SaveState() {


    }
    public void LoadState(Scene s, LoadSceneMode mode) {

    }



}