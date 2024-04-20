using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class process : MonoBehaviour
{
    public Text healthText;
    public Slider bar;

    public void UpdateHealth(int health, int maxHealth)
    {
        healthText.text = health.ToString() + " / " + maxHealth.ToString();
        bar.value = (float)health / (float)maxHealth;
    }

    public void UpdateBar(int value, int maxValue, string text)
    {
        healthText.text = text;
        bar.value = (float)value / (float)maxValue;
    }
}
