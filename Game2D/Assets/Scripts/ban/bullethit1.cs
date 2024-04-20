using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullethit1 : MonoBehaviour
{
    AudioManager audioManager;

    public GameObject bulletEplosion;
    projectile myPC;
    public float weaponDamage;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        myPC = GetComponentInParent<projectile>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Shootable")
        {
            myPC.removeForce();
            Instantiate(bulletEplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            if (collision.gameObject.layer == LayerMask.NameToLayer("enemy"))
            {
                audioManager.PlaySFX(audioManager.no);

                EnemyHeath1 hurtenemy1 = collision.gameObject.GetComponent<EnemyHeath1>();
                hurtenemy1.addDamage(weaponDamage);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shootable")
        {
            myPC.removeForce();
            Instantiate(bulletEplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            if (collision.gameObject.layer == LayerMask.NameToLayer("enemy"))
            {

                audioManager.PlaySFX(audioManager.no);

                EnemyHeath1 hurtenemy1 = collision.gameObject.GetComponent<EnemyHeath1>();
                hurtenemy1.addDamage(weaponDamage);
            }
        }
    }
}
