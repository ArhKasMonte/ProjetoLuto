using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo ator", menuName = "Sistema de diálogo/Novo Ator")]
public class Ator : RecusoDesbloqueavel
{
    [SerializeField] private string nome;
    [SerializeField] private Sprite foto;

     public string Nome
    {
        get
        {
            return nome;
        }
    }

    public Sprite Foto
    {
        get
        {
            return foto;
        }
    }
}
