using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour

{
    private bool isPause;
    public GameObject UIPaused;

    private void Start() {
        UIPaused.SetActive(false);    
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPause){
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPause){
            Play();
        }
    }

    private void Play(){
        isPause = false;
        UIPaused.SetActive(false);
    }

    private void Pause(){
        isPause = true;
        UIPaused.SetActive(true);
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
