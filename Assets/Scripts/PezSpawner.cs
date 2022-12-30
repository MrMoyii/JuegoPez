using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PezSpawner : MonoBehaviour
{
    private float spawnTime;
    [SerializeField]private GameObject pezPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            Instantiate(pezPrefab, GetSpawnPosition(), Quaternion.identity);
            spawnTime = 1.5f;
        }   
    }

    private Vector3 GetSpawnPosition()
    {
        Vector2 limitesPantalla = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        float aleatorioVertical = Random.Range(-limitesPantalla.y, limitesPantalla.y);
        float aleatorioHorizontal = Random.Range(0, 2) == 0 ? -limitesPantalla.x - .9f : limitesPantalla.x + .9f;


        return new Vector3(aleatorioHorizontal, aleatorioVertical, 0);
    }
}
