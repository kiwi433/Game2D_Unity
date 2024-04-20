using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class khoaman6 : MonoBehaviour
{
   [HideInInspector] public static float keynum=1;
    public static khoaman6 khoa;
    private void Start()
    {
        keynum = 1;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }

    private void Collect()
    {
        keynum -= 1;
        Destroy(gameObject);
    }
}
