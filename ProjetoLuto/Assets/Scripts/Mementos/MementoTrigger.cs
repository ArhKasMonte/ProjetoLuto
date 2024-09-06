using UnityEngine;

public class MementoTrigger : MonoBehaviour
{
    [SerializeField] private Memento memento; // Referência ao ScriptableObject Memento

    public Memento ObterMemento()
    {
        return memento;
    }
}