using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[Serializable]
public class FalaDialogo 
{
    [SerializeField, HideInInspector] private string identificador;

    [SerializeField] private Ator ator;
    [SerializeField, TextArea(minLines:3, maxLines:10)] private string texto;

    public Ator Ator
    {
        get
        {
            return ator;
        }
    }

    public string Texto
    {
        get
        {
            return texto;
        }
    }

    public void AtualizarIdentificador()
    {
        if ((ator != null) && (texto != null))
        {
            identificador = "[" + ator.Nome + "]: " + texto;
        }
    }
}
