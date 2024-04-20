using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuuthulinh : MonoBehaviour
{
    public int levelToUnlock;
    public Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    int numberOfUnlockLevel;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            if (NVman5.sothulinh == 0&&collision.gameObject.tag=="Player")
            {
                anim.Play("thulinh_jump");
                GameController.gameController.gameWin();
                numberOfUnlockLevel = PlayerPrefs.GetInt("levelsUnlocked");
                if (numberOfUnlockLevel <= levelToUnlock)
                {
                    PlayerPrefs.SetInt("levelsUnlocked", numberOfUnlockLevel + 1);
                }


            }
        }
    }
}
