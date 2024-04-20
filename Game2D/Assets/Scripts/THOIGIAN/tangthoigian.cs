using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tangthoigian : MonoBehaviour
{
    public Countdown countdown;
    private AudioManager audioManager;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            if (collision.CompareTag("Player"))
            {
                countdown.IncreaseTime(10f);
                // Gọi các hành động khác liên quan đến việc nhặt món đồ ở đây
                Destroy(gameObject);
            }
        }    }
}
