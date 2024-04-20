using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    private Animator anim;
    public static doorScript instance;
    private BoxCollider2D box;   // Danh sách cửa được điều khiển bởi các công tắc
    public List<doorScript> doors = new List<doorScript>();

    // Danh sách các công tắc điều khiển các cửa
    public List<congtac> switches = new List<congtac>();

    private void Awake()
    {
         anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        MakeInstance();
    }
    void MakeInstance()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    public void OpenDoor(int doorIndex)
    {
        if (doorIndex >= 0 && doorIndex < doors.Count)
        {
            doors[doorIndex].Open();
        }
    }
    public void Open()
    {
        anim.SetBool("door", true);
    }
  
    // Start is called before the first frame update
    private void Start()
    {
       
    }

}
