using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteracao : MonoBehaviour
{
    [SerializeField] private List<Memento> mementosObtidos = new List<Memento>();  // Lista de mementos que o jogador possui
    [SerializeField] private Dialogo[] dialogosDisponiveis;  // Lista de di�logos dispon�veis para desbloquear

    private MementoTrigger mementoProximo; // Refer�ncia ao memento que o jogador pode coletar

    private void Update()
    {
        // Se o jogador pressionar uma tecla para interagir com um Memento (por exemplo, E)
        if (Input.GetKeyDown(KeyCode.E) && mementoProximo != null)
        {
            ColetarMemento(mementoProximo.ObterMemento());
            VerificarDesbloqueioDialogos();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Memento"))
        {
            mementoProximo = collision.GetComponent<MementoTrigger>();
            if (mementoProximo != null)
            {
                Debug.Log($"Memento {mementoProximo.ObterMemento().NomeMemento} est� pr�ximo. Pressione 'E' para coletar.");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Memento"))
        {
            mementoProximo = null;
            Debug.Log("Voc� saiu da �rea do Memento.");
        }
    }

    private void ColetarMemento(Memento memento)
    {
        if (!mementosObtidos.Contains(memento))
        {
            mementosObtidos.Add(memento);
            Debug.Log($"Memento {memento.NomeMemento} coletado!");
        }
    }

    private void VerificarDesbloqueioDialogos()
    {
        foreach (Dialogo dialogo in dialogosDisponiveis)
        {
            if (dialogo != null && dialogo.PodeDesbloquearComMemento(mementosObtidos.ToArray()))
            {
                dialogo.Desbloquear();
                Debug.Log($"Di�logo {dialogo.Titulo} foi desbloqueado!");
            }
        }
    }
}