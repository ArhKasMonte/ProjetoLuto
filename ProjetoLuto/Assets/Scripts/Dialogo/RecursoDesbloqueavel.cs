using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecursoDesbloqueavel : ScriptableObject
{
    public delegate void DesbloqueadoDelegate();
    public delegate void BloqueadoDelegate();

    public DesbloqueadoDelegate RecursoDesbloqueado;
    public BloqueadoDelegate RecursoBloqueado;

    [SerializeField] private bool bloqueado;


#if UNITY_EDITOR
    private bool bloqueadoNoEditor;
#endif

#if UNITY_EDITOR
    private void OnEnable()
    {
        bloqueadoNoEditor = bloqueado;
    }
#endif

    public bool Bloqueado
    {
        get
        {
#if UNITY_EDITOR
            return bloqueadoNoEditor;
#else
            return bloqueado;
#endif
        }
    }

    public void Desbloquear()
    {
#if UNITY_EDITOR
        bloqueadoNoEditor = false;
#else
        bloqueado = false;
#endif
        this.RecursoDesbloqueado?.Invoke();
        Debug.Log($"Dialogo {name} foi desbloqueado");
    }

   public void Bloquear()
    {
#if UNITY_EDITOR
        bloqueadoNoEditor = true;
#else
        bloqueado = true;
#endif
        this.RecursoBloqueado?.Invoke();
        Debug.Log($"Dialogo {name} foi bloquedo");
    }
}
