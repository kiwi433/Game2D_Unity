using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDa : MonoBehaviour
{
    AudioManager audioManager;

    private GameObject player;
    public float weaponDamage;
    public float pushbackForce;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            HeartScript hurtPlayer = collision.gameObject.GetComponent<HeartScript>();
            hurtPlayer.addDamage(weaponDamage);


            pushback(collision.transform);
        }
    }
 
    void pushback(Transform pushObject)
    {
        Vector2 pushDriretion = new Vector2(0, (pushObject.position.x - transform.position.x)).normalized;
        pushDriretion *= pushbackForce;
        Rigidbody2D pushRB = pushObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDriretion, ForceMode2D.Impulse);
    }
}
