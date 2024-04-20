using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHeath1 : MonoBehaviour
{

    public float maxheath;
    float currentHeath;
    private static int enemiesDefeated = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentHeath = maxheath;
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addDamage(float damage)
    {
        currentHeath -= damage;

        if (currentHeath <= 0)
            makeDead();
    }
    void makeDead()
    {
        enemiesDefeated++;
        int defeatedScore = ScoreManager.Instance.CalculateEnemyDefeatedScore(1);
        ScoreManager.Instance.AddScore(defeatedScore);
        Debug.Log("Enemy is defeated. Enemies defeated: " + enemiesDefeated+"số điểm " );
        Destroy(gameObject);
        /* Instantiate(enemyHeathEF,transform.position,transform.rotation);*/
    }
}
