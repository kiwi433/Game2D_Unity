using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHeath : MonoBehaviour
{
    public float maxheath;
    float currentHeath;
    // khai bao cac bien de tao thanh mau
    public Slider enemyHeathSlider;
    // Start is called before the first frame update
    public GameObject[] itemDrops;
    public GameObject pumding;
    private static int enemiesDefeated = 0;
    private void ItemDrop()
    {
        for (int i = 0; i < itemDrops.Length; i++)
        {
            Instantiate(itemDrops[i], transform.position + new Vector3(0, 1, 0), Quaternion.identity); ;
        }
    }
    void Start()
    {
        currentHeath = maxheath;
        enemyHeathSlider.maxValue = maxheath;
        enemyHeathSlider.value = maxheath;
    }
    public void addDamage(float damage)
    {
        enemyHeathSlider.gameObject.SetActive(true);
        currentHeath -= damage;
        enemyHeathSlider.value = currentHeath;
        if (currentHeath <= 0) 
         
            makeDead();
    }
    void makeDead()
    { 
        ItemDrop();
        pumding.SetActive(false);
        Hienthiquai.soquai -= 1;
        Destroy(gameObject);   
        enemiesDefeated++;
        int defeatedScore = ScoreManager.Instance.CalculateEnemyDefeatedScore(1);
        ScoreManager.Instance.AddScore(defeatedScore);
        Debug.Log("Enemy is defeated. Enemies defeated: " + enemiesDefeated + "số điểm "+ defeatedScore);
    }
}
