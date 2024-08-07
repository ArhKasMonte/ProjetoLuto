using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TelaDialogo : MonoBehaviour
{
    [SerializeField] private Image fotoAtor;
    [SerializeField] private TextMeshProUGUI textoNomeAtor;
    [SerializeField] private TextMeshProUGUI textoFalaDialogo;
    [SerializeField] private float intervaloTempoEntreLetrasEmSegundos;

    private Coroutine preencherTextoCoroutine;
    private Dialogo dialogo;

    private static TelaDialogo instancia;

    private void Awake()
    {
        instancia = this;
        Esconder();
    }

    public static TelaDialogo Instancia
    {
        get
        {
            return instancia;
        }
    }

    public void Exibir(Dialogo dialogo)
    {
        this.dialogo = dialogo;
        this.dialogo.Iniciar();

        gameObject.SetActive(true);
        ExibirFalaAtual();
    }

    public void Avancar()
    {
        if (dialogo.TemProximaFala())
        {
            dialogo.Avancar();
            ExibirFalaAtual();
        }
        else
        {
            dialogo.Concluir();
            Esconder();
        }
    }

    public void Esconder()
    {
        gameObject.SetActive(false);
    }

    public void ExibirFalaAtual()
    {
        FalaDialogo falaAtual = dialogo.FalaAtual;
        Ator ator = falaAtual.Ator;
        fotoAtor.sprite = ator.Foto;
        textoNomeAtor.text = ator.Nome;
        //textoFalaDialogo.text = falaAtual.Texto;

        if (preencherTextoCoroutine != null)
        {
            StopCoroutine(preencherTextoCoroutine);
        }
        preencherTextoCoroutine = StartCoroutine(PreencherConteudoTextoAosPoucos(falaAtual.Texto));
    }

    private IEnumerator PreencherConteudoTextoAosPoucos(string texto)
    {
        textoFalaDialogo.text = "";
        for (int i = 0; i < texto.Length; i++)
        {
            textoFalaDialogo.text += texto[i];
            yield return new WaitForSeconds(intervaloTempoEntreLetrasEmSegundos);
        }
    }
}
