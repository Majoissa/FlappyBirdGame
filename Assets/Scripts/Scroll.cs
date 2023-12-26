using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 2.5f; //va a determinar la velocidad del fondo que se va a desplazar hacia la izquierda cuando el ponga el signo -
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * speed; //es lo mismo que estabamos haciendo abajo
        //rb.velocity = new Vector2(-speed, 0f);//aqui aplico el signo - para que la velocidad se aplique hacia la izquierda
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.isGameOver)
        {
            rb.velocity = Vector2.zero; //reseteo su velocidad a zero
        }
    }
}
