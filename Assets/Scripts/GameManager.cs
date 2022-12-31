using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia { get; private set; }

    private MaquinaDeEstados maquinaDeEstados;

    [SerializeField] private GameObject perdistePanel;
    [SerializeField] private GameObject ganastePanel;
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
                perdistePanel.SetActive(true);
                break;
            case MaquinaDeEstados.JuegoGanado:
                ganastePanel.SetActive(true);
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
