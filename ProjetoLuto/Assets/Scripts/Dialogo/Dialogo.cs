using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Novo dialogo", menuName ="Sistema de diálogo/Novo diálogo")]
public class Dialogo : RecusoDesbloqueavel
{
    [SerializeField] private FalaDialogo[] falasdialogos;

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
        if (indiceFalaAtual < (falasdialogos.Length - 1))
        {
            return true;
        }
        return false;
    }
}
