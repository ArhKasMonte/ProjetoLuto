using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogo : MonoBehaviour
{
    [SerializeField] private Ator ator;
    [SerializeField] private Dialogo[] dialogos;

    private bool playerNoRange = false;

    private void Awake()
    {
        if (ator.Bloqueado)
        {
            Esconder();
        }
        ator.RecursoDesbloqueado += Exibir;
        ator.RecursoBloqueado += Esconder;
    }
    private void Update()
    {
        Dialogo();
    }
    public void Dialogo()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (playerNoRange)
            {
                TelaListaDialogo.Instance.Exibir(ator, ObeterDialogosDesbloqueados());
            }
        }
    }

    private List<Dialogo> ObeterDialogosDesbloqueados()
    {
        List<Dialogo> dialogosDesbloqueados = new List<Dialogo>();
        foreach (Dialogo dialogo in dialogos)
        {
            if (!dialogo.Bloqueado)
            {
                dialogosDesbloqueados.Add(dialogo);
            }
        }
        return dialogosDesbloqueados;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerDialogo")
        {
            playerNoRange = true;
            Debug.Log($"Entrou no range para falar {playerNoRange}");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerDialogo")
        {
            playerNoRange = false;
            Debug.Log($"Saiu do range para falar {playerNoRange}");

        }
    }

    private void Esconder()
    {
        this.gameObject.SetActive(false);
    }

    private void Exibir()
    {
        this.gameObject.SetActive(true);
    }
}
    