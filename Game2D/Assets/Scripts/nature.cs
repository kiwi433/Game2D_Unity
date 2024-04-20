using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nature : MonoBehaviour
{
    public int maxNature = 3;
    public int currentNature;


    // Start is called before the first frame update
    void Start()
    {
        currentNature = maxNature;
    }

    // Update is called once per frame
    void TakeDamage(int amount)
    {
        currentNature -= amount;
        if(currentNature<=0)
        {

        }
    }
}
