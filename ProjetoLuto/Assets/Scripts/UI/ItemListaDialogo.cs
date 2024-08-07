using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemListaDialogo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tituloTexto;

    private Dialogo dialogo;

    public void Configurar(Dialogo dialogo)
    {
        this.dialogo = dialogo;
        this.tituloTexto.text = dialogo.Titulo;
    }

    public void OnClick()
    {
        TelaListaDialogo.Instance.Esconder();
        TelaDialogo.Instancia.Exibir(dialogo);
    }
}
