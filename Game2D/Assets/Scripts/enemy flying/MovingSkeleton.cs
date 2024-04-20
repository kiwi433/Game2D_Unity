using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSkeleton : MonoBehaviour
{  
    private GameObject player;
    public bool chase = false;
    [SerializeField] private float speed = 2f;[SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (player == null)
        {
            return;

        }
        if (chase == true)
        { 
            Chase();
        }
        else
        {
           
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }

        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed); 
            Flip();
        }
    }
    private void Chase()
    {
        FlipPlayer();
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    private void Flip()
    {
        // Get the direction of movement
        Vector2 direction = (waypoints[currentWaypointIndex].transform.position - transform.position).normalized;

        // Check if the direction is towards the left
        if (direction.x < 0)
        {
            // Flip the sprite to face left
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            // Flip the sprite to face right
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    private void FlipPlayer()
    {
        // Lấy hướng từ con xương tới người chơi
        Vector2 directionToPlayer = (player.transform.position - transform.position).normalized;

        // Kiểm tra xem hướng có phải là hướng sang trái hay không
        if (directionToPlayer.x < 0)
        {
            // Đảo chiều hướng của sprite để nhìn về bên trái
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            // Đảo chiều hướng của sprite để nhìn về bên phải
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
