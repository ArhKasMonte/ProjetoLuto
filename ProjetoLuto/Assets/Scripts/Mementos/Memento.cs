using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo Memento", menuName = "Sistema de Mementos/Novo Memento")]
public class Memento : ScriptableObject
{
    [SerializeField] private string nomeMemento;  // Nome do Memento
    [SerializeField] private string descricao;    // Descrição do Memento

    public string NomeMemento
    {
        get { return nomeMemento; }
    }

    public string Descricao
    {
        get { return descricao; }
    }
}