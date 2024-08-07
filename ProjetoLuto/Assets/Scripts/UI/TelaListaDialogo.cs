using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TelaListaDialogo : MonoBehaviour
{
    [SerializeField] private Image fotoAtor;
    [SerializeField] private TextMeshProUGUI nomeAtor;
    [SerializeField] private Transform scrollConteudo;
    [SerializeField] private ItemListaDialogo itemListaDialogoPrefab;

    private static TelaListaDialogo instance;

    private void Awake()
    {
        instance = this;
        Esconder();
    }

    public static TelaListaDialogo Instance
    {
        get
        {
            return instance;
        }
    }

    public void Esconder()
    {
        gameObject.SetActive(false);
        Limpar();
    }

    public void Exibir(Ator ator, List<Dialogo> dialogos)
    {
        fotoAtor.sprite = ator.Foto;
        nomeAtor.text = ator.Nome;

        foreach (Dialogo dialogo in dialogos)
        {
            ItemListaDialogo itemListaDialogo = Instantiate(itemListaDialogoPrefab, scrollConteudo);
            itemListaDialogo.Configurar(dialogo);
        }
        gameObject.SetActive(true);
    }

    public void Limpar()
    {
        int quantidadeItens = scrollConteudo.childCount;
        for (int i = 0; i < quantidadeItens; i++)
        {
           Transform objetoFilho = scrollConteudo.GetChild(i);
            Destroy(objetoFilho.gameObject);
        }
    }
}
