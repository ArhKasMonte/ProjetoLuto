using UnityEngine;

public class MementoTrigger : MonoBehaviour
{
    [SerializeField] private Memento memento; // Refer�ncia ao ScriptableObject Memento

    public Memento ObterMemento()
    {
        return memento;
    }
}