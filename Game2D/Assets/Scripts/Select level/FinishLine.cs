using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public int levelToUnlock;
    int numberOfUnlockLevel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            numberOfUnlockLevel = PlayerPrefs.GetInt("levelsUnlocked");
            if(numberOfUnlockLevel<=levelToUnlock)
            {
                PlayerPrefs.SetInt("levelsUnlocked", numberOfUnlockLevel + 1);
            }
        }
    }
}
