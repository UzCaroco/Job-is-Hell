using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoNPC : MonoBehaviour
{

    [SerializeField] private Sprite spriteNPC;
    [SerializeField] private string[] textoDialogo;
    [SerializeField] private string nomePersonagem;

    private ControleDialogos scriptControleDialogos;
    //private Collider2D colisor;
    //private bool permiteInteracaoBOOL;
    private bool dialogoIniciado;

    //[SerializeField] private float raioColisao;
    [SerializeField] private LayerMask layerMask;

    private void Start()
    {
        //Quando iniciar o jogo, será procurado um objeto que contenha o script "ControleDialogos"
        //é uma maneira de ativar outro script por meio de outro script
        scriptControleDialogos = FindObjectOfType<ControleDialogos>();
    }
    private void FixedUpdate()
    {
        //InteracaoComNPC();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E) && permiteInteracaoBOOL && !dialogoIniciado)
        //{
        //    scriptControleDialogos.Personagem(spriteNPC, textoDialogo, nomePersonagem, this);
        //    dialogoIniciado = true;
        //}

        if (Input.GetKeyDown(KeyCode.E) && !dialogoIniciado)
        {
            scriptControleDialogos.Personagem(spriteNPC, textoDialogo, nomePersonagem);
            dialogoIniciado = true;
        }
    }

    //public void InteracaoComNPC()
    //{
    //    colisor = Physics2D.OverlapCircle(transform.position, raioColisao, layerMask);

        //Se o objeto estiver dentro da área de interação
    //    if (colisor != null )
    //    {
    //        permiteInteracaoBOOL = true;
    //    }
    //    else
    //    {
    //        permiteInteracaoBOOL = false;
    //    }
    //}

    public void FimDoDialogo(bool resposta)
    {
        dialogoIniciado = resposta;
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.DrawWireSphere(transform.position, raioColisao);
    //}
}
