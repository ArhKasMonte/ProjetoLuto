using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Anima��o")]
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [Header("Movimenta��o")]
    [SerializeField]
    private Rigidbody2D rigidbody2d;

    [SerializeField]
    private float velocidadeMovimento; // Alterar na velocidade do personagem no inspetor

    private bool parado = true;
    private bool podeMover = true; // Adiciona uma vari�vel para controlar o movimento
    private int inputXHash = Animator.StringToHash("InputX");
    private int inputYHash = Animator.StringToHash("InputY");

    private Vector2 direcaoMov;

    private void FixedUpdate()
    {
        if (podeMover)
        {
            MovePlayer();
        }
    }

    void Update()
    {
        GetMoveDirection();
        if (Input.GetKeyDown(KeyCode.Z))
        {
            podeMover = !podeMover; // Alterna a capacidade de movimenta��o
            PlayerDialogo.Instancia.Dialogo();
        }
    }

    private void LateUpdate()
    {
        AnimacaoPlayer();
    }

    private void GetMoveDirection()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // Pega a informa��o se � -1 ou 1
        float vertical = Input.GetAxisRaw("Vertical"); // Pega a informa��o se � -1 ou 1

        direcaoMov = new Vector2(horizontal, vertical).normalized; // Pegando o X e o Y
    }

    private void MovePlayer()
    {
        if (parado == true && direcaoMov != Vector2.zero)
        {
            rigidbody2d.velocity = direcaoMov * velocidadeMovimento; // Pegando o X e o Y e multiplicando pela velocidade definida no inspetor

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
}