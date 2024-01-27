using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public float upForce = 3500f;
    public float rotation = 2f;
    bool isDead = false;
    private Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>(); //a partir de esto voy a poder aplicar fuerzas verticales para que el pajaro de saltos
        playerAnimator = GetComponent<Animator>();//obtengo el componente animator
    }
    // Update is called once per frame
    void Update()
    {   //si se presiona la tecla espaciadora o hay al menos un toque en la pantalla
        if((Input.GetKey(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) && !isDead)  //si presiona tecla space y pajaro no ha muerto
        {
           Flap();
        }
        else if (!isDead)
        {
           transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 4f * Time.deltaTime);
        }
    }

    private void Flap()
    {
        playerRb.velocity = Vector2.zero; //para tener siempre la misma altura de salto detengo completamente el pajaro antes de aplicarle la fuerza
        playerRb.AddForce(Vector2.up * upForce); //al rb le agrego el vector 2d up para que suba, y le doy la fuerza de upForce
        playerRb.transform.Rotate(0f, 0f, rotation);
        playerAnimator.SetTrigger("Flap"); //aplico la animacion de flap. Disparo el trigger flap
    }

    //metodo para verificar si colisiona con algo y cambiar el isDead a verdadero
    private void OnCollisionEnter2D()
    {
        isDead = true;
        playerAnimator.SetTrigger("Die"); //disparo el trigger die
        GameManager.Instance.GameOver();//Llamo a la instancia del game manager para usar su metodo game over
    }
}
