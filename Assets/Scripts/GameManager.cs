using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public bool isGameStarted = false;
    public GameObject platformSpawner;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }    
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameStarted) {
            if(Input.GetMouseButtonDown(0)) {
                GameStart();
            }
        }
    }

    public void GameStart() {
        isGameStarted = true;
        platformSpawner.SetActive(true);
    }

    public void GameOver() {
        isGameStarted = false;
        platformSpawner.SetActive(false);
        Invoke("ReloadLevel", 1f);
    }

    void ReloadLevel() {
        SceneManager.LoadScene("Game");
    }
}
