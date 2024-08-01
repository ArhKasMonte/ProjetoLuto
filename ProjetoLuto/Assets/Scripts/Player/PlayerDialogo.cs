using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogo : MonoBehaviour
{
    [SerializeField] private Dialogo dialogo;

    private static PlayerDialogo instancia;
    private bool playerNoRange = false;

    private void Awake()
    {
        instancia = this;
    }

    public static PlayerDialogo Instancia
    {
        get
        {
            return instancia;
        }
    }

    public void Dialogo()
    {
        if (playerNoRange)
        {
            TelaDialogo.Instancia.Exibir(dialogo);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerDialogo")
        {
            playerNoRange = true;
            Debug.Log("Entrou no range para falar");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerDialogo")
        {
            playerNoRange = false;
            Debug.Log("Saiu do range para falar");
        }
    }
}
    