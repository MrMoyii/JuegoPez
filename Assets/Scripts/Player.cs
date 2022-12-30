using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidad = 3;
    private float tamanio = 1;
    private int pecesComidos = 0;

    [SerializeField]private Transform pezSprite;

    // Start is called before the first frame update
    void Start()
    {
        tamanio = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        //----------------Movimiento----------------
        float inputVertical = Input.GetAxis("Vertical") * Time.deltaTime * velocidad;
        float inputHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * velocidad;

        //transform.position = transform.position + new Vector3(inputHorizontal, inputVertical, 0);
        transform.Translate(new Vector3(inputHorizontal, inputVertical, 0));

        //----------------Evitar Salir de la pantalla----------------
        Vector2 limitesPantalla = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, limitesPantalla.x * -1, limitesPantalla.x),
            Mathf.Clamp(transform.position.y, limitesPantalla.y * -1, limitesPantalla.x),
            0
            );

        //----------------Rotacion----------------
        if (inputHorizontal == 0) return;
        if (inputHorizontal < 0)
        {
            pezSprite.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        else
        {
            pezSprite.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pez"))
        {
            PezIA pezIa =  collision.gameObject.GetComponent<PezIA>();
            if (tamanio >= pezIa.Tamanio)
            {
                pecesComidos++;
                
                transform.localScale += new Vector3(0.1f, 0.1f,0.1f);
                tamanio = transform.localScale.x;

                Destroy(collision.gameObject);
            }
            else { Debug.Log("GameOver"); Destroy(gameObject); }
            
        }
    }
}
