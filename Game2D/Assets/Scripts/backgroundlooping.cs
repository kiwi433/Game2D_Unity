using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundlooping : MonoBehaviour
{
    public static backgroundlooping insatnce;
    public float backgroundSpeed;
    public Renderer backgroundRenderer;
    public bool isFrozen = false; 
    private void Start()
    {
        isFrozen= false;
        GameController.gameController = FindObjectOfType<GameController>();
    }
    void Update()
    {

        if (!isFrozen) // Kiểm tra xem background có nên di chuyển không
        {
            if ( !GameController.gameController.gamePauseUI.activeSelf && GameObject.FindGameObjectWithTag("Player") != null)
            {
                backgroundRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0f);
            }
        }

    }
 

}
