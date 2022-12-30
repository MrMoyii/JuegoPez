using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PezIA : MonoBehaviour
{
    public float speed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.right * Time.deltaTime * speed);


        //Limites pantalla
        Vector2 limitesPantalla = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        if (transform.position.x > limitesPantalla.x + 1 || transform.position.x <= -limitesPantalla.x -1)
        {
            Destroy(gameObject);
        }

    }
}
