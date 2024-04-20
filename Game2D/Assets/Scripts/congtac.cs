using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class congtac : MonoBehaviour
{

    private Animator anim;
    public int doorIndex = 0;
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
           
            if (collision.tag == "Player")
            {
                anim.SetBool("congtac", true);
              
               
                doorScript.instance.OpenDoor(doorIndex);
            }
           
        }
    }
   
}
