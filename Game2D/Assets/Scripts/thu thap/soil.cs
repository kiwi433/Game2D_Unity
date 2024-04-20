using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class soil : MonoBehaviour
{
    AudioManager audioManager;

    public Text soilSampleText;
    public static int soilNum;
    public int maxHealth;
    [HideInInspector] public static int currentHealth;
    public static soil instance;
    public process healthBar;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();


    }
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();


    }
    void UpdateScore()
    {
        currentHealth = 0;
        soilNum = 5;
        soilSampleText.text = "X" + soilNum;
        if (healthBar != null)
            healthBar.UpdateHealth(currentHealth, maxHealth);
    }
    // Update is called once per frame
    void Update()
    {
        soilSampleText.text = "X" + soilNum; 
        healthBar.UpdateHealth(currentHealth, maxHealth);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioManager.PlaySFX(audioManager.collect);
            soilNum -= 1;
            currentHealth += 20;
            soilNum++;
            
            Destroy(gameObject);  
        }
    }



}
