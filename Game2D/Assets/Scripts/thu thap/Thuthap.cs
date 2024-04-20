using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thuthap : MonoBehaviour
{
    AudioManager audioManager;
    public int scoreValue = 10;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
             ScoreManager.Instance.AddScore(scoreValue);
            audioManager.PlaySFX(audioManager.collect);

            Destroy(gameObject);
        }
    }
}
