using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Animação")]
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [Header("Movimentação")]
    [SerializeField]
    private Rigidbody2D rigidbody2d;

    [SerializeField]
    private float velocidadeMovimento; //Alterar na velocidade do personagem no inspetor

    bool movendo = false;
    bool parado = true;
    private int inputXHash = Animator.StringToHash("InputX");
    private int inputYHash = Animator.StringToHash("InputY");


    Vector2 direcaoMov;

    private void FixedUpdate()
    {

        MovePlayer();
    }

    void Update()
    {
        GetMoveDirection();
    }

    private void LateUpdate()
    {
        AnimacaoPlayer();
    }
    private void GetMoveDirection()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");// pegar a informação se é -1 ou 1
        float vertical = Input.GetAxisRaw("Vertical");// pegar a informação se é -1 ou 1

        direcaoMov = new Vector2(horizontal, vertical).normalized;// Pegando o X e o Y

        //Debug.Log(direcaoMov + " -> " + direcaoMov.magnitude);// vizualizar o X e Y durante o jogo
    }

    private void MovePlayer()
    {
        if (parado == true && direcaoMov != Vector2.zero)
        {
            rigidbody2d.velocity = direcaoMov * velocidadeMovimento;// Pegando o X e o Y e mutiplicando pela velocidade definida no inspetor


            if (direcaoMov.x > 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (direcaoMov.x < 0)
            {
                spriteRenderer.flipX = false;

            }
        }
        else
        {
            rigidbody2d.velocity = Vector2.Lerp(rigidbody2d.velocity, Vector2.zero, 0.9f);
        }
    }

    void AnimacaoPlayer()
    {
        if (direcaoMov.x != 0 || direcaoMov.y != 0)
        {
            animator.SetFloat(inputXHash, direcaoMov.x);
            animator.SetFloat(inputYHash, direcaoMov.y);

            animator.SetBool("Player_Run", true);
        }
        else
        {
            animator.SetBool("Player_Run", false);
        }

    }

    void BloquearMovimento()
    {
        parado = false;
    }

    void LiberarMovimento()
    {
        parado = true;
    }
}