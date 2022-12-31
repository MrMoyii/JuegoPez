using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia { get; private set; }

    private MaquinaDeEstados maquinaDeEstados;
    private void Awake()
    {
        if (Instancia != null) Destroy(gameObject);
        else Instancia = this;
    }

    public void ActualizarMaquinaEstados(MaquinaDeEstados nuevoEstado)
    {
        switch (nuevoEstado)
        {
            case MaquinaDeEstados.Jugando:
                break;
            case MaquinaDeEstados.JuegoTeminado:
                Debug.Log("Game Oveeer");
                break;
            case MaquinaDeEstados.JuegoGanado:
                Debug.Log("Game Win");
                break;
            default:
                break;
        }
    }
}

public enum MaquinaDeEstados
{
    Jugando,
    JuegoTeminado,
    JuegoGanado
}
