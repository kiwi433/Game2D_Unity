using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dichchuyen : MonoBehaviour
{
    [SerializeField] GameObject Cong;
    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }
    // Update is called once per frame
    void Update()
    {
        if(Cong!=null)
        {
            transform.position = Cong.GetComponent<congdichchuyen>().GetDiemDichChuyenDen().position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("congdichchuyen"))
        {
            audioManager.PlaySFX(audioManager.dichchuyen);
            Cong = collision.gameObject;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("congdichchuyen"))
        {
            Cong = null;

        }
    }
}
