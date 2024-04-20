using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public float cameraSpeed;
    private void Start()
    {
        GameController.gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameController.gameController.gamePauseUI.activeSelf && GameObject.FindGameObjectWithTag("Player") != null)
        {
            // Move the camera
            transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
        }
    }
}
