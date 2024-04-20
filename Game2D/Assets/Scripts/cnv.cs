using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cnv : MonoBehaviour
{
    AudioManager audioManager;
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
        if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }
        if (collision.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Player")
        {
            HeartScript.health -= 1;
            audioManager.PlaySFX(audioManager.dungTrap);

            if (HeartScript.health == 0)
            {
                Destroy(player.gameObject);
            }


        }
    }

}
