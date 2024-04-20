using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    public static ScenesController instance;
    [SerializeField] RectTransform fader;
    AudioManager audioManager;
    [SerializeField] GameObject[] introductionPanels; // Mảng chứa các panel giới thiệu
    public float[] introductionDurations; // Mảng chứa độ dài của các phần giới thiệu
    public int currentSceneIndex = 0; // Chỉ mục của màn đang chơi
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
       

    }
    public void Start()
    {//Scale

      ShowIntroduction();
    }


    public void ShowIntroduction()
    {
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0);
        LeanTween.scale(fader, Vector3.zero, 0.5f)
            .setEase(LeanTweenType.easeInOutExpo)
            .setOnComplete(() =>
            {
                Debug.Log("Tween completed!");
                DisableFader();
                
            });

        if (currentSceneIndex >= 0 && currentSceneIndex < introductionPanels.Length)
        {
          
            introductionPanels[currentSceneIndex].SetActive(true);
            Invoke("DisableIntroductionPanel", introductionDurations[currentSceneIndex]);
          
        }
        
    }

    public void DisableFader()
    {
        fader.gameObject.SetActive(false);
     
    }

    private void DisableIntroductionPanel()
    {   
        if (currentSceneIndex >= 0 && currentSceneIndex < introductionPanels.Length)
        {
            introductionPanels[currentSceneIndex].SetActive(false);
         
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OpenMenuScence()
    { 
        audioManager.PlaySFX(audioManager.playButton);
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, Vector3.zero, 0f);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(() =>
        {
            audioManager.SaveVolumeSettings();
         
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
        );
    }
    public void OpenGameScence()
    {
        fader.gameObject.SetActive(true);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0);
        LeanTween.scale(fader, Vector3.zero, 0.5f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() =>
        {
         
            Invoke("LoadGame", 0.5f);
        }
        );
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

    }
   
    public void Home(int index)
    {
        SceneManager.LoadScene(index);
    }    
}
