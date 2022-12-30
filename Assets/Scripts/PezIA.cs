using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PezIA : MonoBehaviour
{
    private int dir = 1;
    private float tamanio;

    public float Tamanio { get => tamanio; }

    Vector2 limitesPantalla;

    [SerializeField] private float speed = 1.5f;
    [SerializeField] private Transform pezSprite;

    // Start is called before the first frame update
    void Start()
    {
        //Limites pantalla
        limitesPantalla = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        if (transform.position.x <= limitesPantalla.x/2)
        {
            dir = 1;
            pezSprite.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else
        {
            dir = -1;
            pezSprite.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }

        //Tamaño Aleatorio
        float tamanioAleatorio = Random.Range(0.5f, 2.5f);
        tamanio = tamanioAleatorio;

        transform.localScale = new Vector3(tamanioAleatorio, tamanioAleatorio, tamanioAleatorio);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.right * dir * Time.deltaTime * speed);


        if (transform.position.x > limitesPantalla.x + 1 || transform.position.x <= -limitesPantalla.x -1)
        {
            Destroy(gameObject);
        }

    }
}
