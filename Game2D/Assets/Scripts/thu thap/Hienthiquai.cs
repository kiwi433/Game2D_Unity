using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hienthiquai : MonoBehaviour
{
    public Text quaiText;
    public static int soquai;
    public static Hienthiquai instance;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();

    }
    void UpdateScore()
    {

        soquai = 10;
        quaiText.text = "X" + soquai;

    }
    // Update is called once per frame
    void Update()
    {
        quaiText.text = "X" + soquai;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            soquai -= 1;

            Destroy(gameObject);


        }
    }
}
