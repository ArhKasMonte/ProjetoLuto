using UnityEngine;

public class MementoTrigger : MonoBehaviour
{
    [SerializeField] private Memento memento; // ReferÍncia ao ScriptableObject Memento

    public Memento ObterMemento()
    {
        return memento;
    }
}