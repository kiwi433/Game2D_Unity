using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingscipt : MonoBehaviour
{
    AudioManager audioManager;
    public GameObject gamePauseUI;
   [SerializeField] public GameObject HdUI;
    // Start is called before the first frame update
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void gamePause()
    {
        audioManager.PlaySFX(audioManager.playButton);
        gamePauseUI.SetActive(true);
        Time.timeScale = 1f;
    }public void exitPanel()
    {
        audioManager.PlaySFX(audioManager.playButton);
        gamePauseUI.SetActive(false);
        Time.timeScale = 1f;
    }    public void HD()
    {
        audioManager.PlaySFX(audioManager.playButton);
        HdUI.SetActive(true);
        Time.timeScale = 1f;
    }public void exitHD()
    {
        audioManager.PlaySFX(audioManager.playButton);
        HdUI.SetActive(false);
        Time.timeScale = 1f;
    }

}
