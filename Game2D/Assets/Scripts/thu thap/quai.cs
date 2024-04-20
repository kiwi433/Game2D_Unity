using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quai : MonoBehaviour
{
    public int levelToUnlock;
    int numberOfUnlockLevel;
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            if (Hienthiquai.soquai == 0)
            {
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
