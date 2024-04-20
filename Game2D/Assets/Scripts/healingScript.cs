using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healingScript : MonoBehaviour
{
    AudioManager audioManager;
    private GameObject player;
    private GameObject heart;
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
        if (collision.tag == "Player" && HeartScript.health < 3)
        {

            HeartScript.health += 1;
            audioManager.PlaySFX(audioManager.collect);
            Destroy(gameObject);


        }
     
    }
}
