using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo dialogo", menuName = "Sistema de diálogo/Novo diálogo")]
public class Dialogo : RecursoDesbloqueavel
{
    [SerializeField] private string titulo;
    [SerializeField] private FalaDialogo[] falasdialogos;
    [SerializeField] private Memento[] mementosNecessarios;  // Mementos necessários para desbloquear este diálogo
    [SerializeField] private RecursoDesbloqueavel[] recursosParaDesbloquear;
    [SerializeField] private RecursoDesbloqueavel[] recursosParaBloquear;

    private int indiceFalaAtual;

    private void OnValidate()
    {
        foreach (FalaDialogo falaDialogo in falasdialogos)
        {
            falaDialogo.AtualizarIdentificador();
        }
    }

    public void Iniciar()
    {
        indiceFalaAtual = 0;
    }

    public string Titulo
    {
        get { return titulo; }
    }

    public FalaDialogo FalaAtual
    {
        get
        {
            if (indiceFalaAtual < falasdialogos.Length)
            {
                return falasdialogos[indiceFalaAtual];
            }
            return null;
        }
    }

    public void Avancar()
    {
        if (TemProximaFala())
        {
            indiceFalaAtual++;
        }
    }

    public bool TemProximaFala()
    {
        return indiceFalaAtual < (falasdialogos.Length - 1);
    }

    public bool PodeDesbloquearComMemento(Memento[] mementosObtidos)
    {
        foreach (Memento mementoNecessario in mementosNecessarios)
        {
            if (!System.Array.Exists(mementosObtidos, memento => memento == mementoNecessario))
            {
                return false;
            }
        }
        return true;
    }

    public void Concluir()
    {
        foreach (RecursoDesbloqueavel recursoParaDesbloquear in recursosParaDesbloquear)
        {
            if (recursoParaDesbloquear.Bloqueado)
            {
                recursoParaDesbloquear.Desbloquear();
            }
        }
        foreach (RecursoDesbloqueavel recursoParaBloquear in recursosParaBloquear)
        {
            if (!recursoParaBloquear.Bloqueado)
            {
                recursoParaBloquear.Bloquear();
            }
        }
    }
}