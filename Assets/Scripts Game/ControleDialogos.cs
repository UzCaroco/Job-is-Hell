using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ControleDialogos : MonoBehaviour
{

    [Header("Componentes")]

    //Vai controlar o objeto de diálogos
    public TMP_InputField inputField;
    public string nomeDoPersonagemPrincipal;

    [SerializeField] private TextMeshProUGUI conteudoTexto;
    public TextMeshProUGUI nomeDoPersonagem;
    [SerializeField] private GameObject TresOpcoes;
    [SerializeField] private Image imagemPerfil;
    [SerializeField] private Sprite imagemPerfilInicial;
    [SerializeField] private TextMeshProUGUI botao1;
    [SerializeField] private TextMeshProUGUI botao2;
    [SerializeField] private TextMeshProUGUI botao3;
    [SerializeField] private TextMeshProUGUI botao4;
    [SerializeField] private TextMeshProUGUI botao5;
    public GameObject controleDeDialogos;
    public GameObject DuasOpcoes;
    public GameObject BotaoDePular;

    [Header("Configurações")]

    [SerializeField] private float velocidadeTexto;
    private string[] textosDialogos;
    private int index;
    private int fala = 0;

    private bool textoCompleto;

    public bool dialogoInicial;
    private bool controlarTextoInicial;

    public string[] textoInicial;
    public string nomeInicial;

    private int perguntas = 1;



    //--------------------------------------------------------------//
    //---------------------------//
    //--------------------------------------------------//

    private Sprite[] spritesSequencia;
    private string[] nomesSequencia;

    public int sequenciaDeDialogos;
    private int falaSequencia = 0;

    public bool ativarOpcao;

    private void Start()
    {
        nomeDoPersonagemPrincipal = PlayerPrefs.GetString("nomeDoJogador");
        Debug.Log("Nome do Jogador: " + nomeDoPersonagemPrincipal);
    }
    private void FixedUpdate()
    {
        if (dialogoInicial)
        {
            dialogoInicial = false;
            controlarTextoInicial = true;
            Personagem(imagemPerfilInicial, textoInicial, nomeDoPersonagemPrincipal);
        }

        if (controlarTextoInicial)
        {
            if (perguntas == 1)
            {
                botao4.text = "Não, mas estavam quase.";
                botao5.text = "Sim, dormiram.";
            }

            switch (fala)
            {
                case 0:
                    {
                        nomeDoPersonagem.text = nomeDoPersonagemPrincipal;
                        break;
                    }
                case 1:
                    {
                        nomeDoPersonagem.text = "Maya";
                        break;
                    }
                case 2:
                    {
                        nomeDoPersonagem.text = nomeDoPersonagemPrincipal;
                        break;
                    }
                case 3:
                    {
                        nomeDoPersonagem.text = nomeDoPersonagemPrincipal;
                        break;
                    }
                case 4:
                    {
                        nomeDoPersonagem.text = nomeDoPersonagemPrincipal;
                        conteudoTexto.fontStyle = FontStyles.Italic;
                        break;
                    }
                case 5:
                    {
                        nomeDoPersonagem.text = "Ran";
                        conteudoTexto.fontStyle = FontStyles.Normal;
                        break;
                    }
                case 6:
                    {
                        nomeDoPersonagem.text = "Maya";
                        break;
                    }
                case 7:
                    {
                        nomeDoPersonagem.text = nomeDoPersonagemPrincipal;
                        break;
                    }
                case 8:
                    {
                        nomeDoPersonagem.text = "Hanna";
                        DuasOpcoes.SetActive(true);
                        BotaoDePular.SetActive(false);
                        controlarTextoInicial = false;
                        break;
                    }
            }
        }



        if (ativarOpcao)
        {
            switch (falaSequencia)
            {
                case 0:
                    {
                        nomeDoPersonagem.text = nomesSequencia[0];
                        imagemPerfil.sprite = spritesSequencia[0];
                        break;
                    }
                case 1:
                    {
                        nomeDoPersonagem.text = nomesSequencia[1];
                        imagemPerfil.sprite = spritesSequencia[1];
                        break;
                    }
                case 2:
                    {
                        nomeDoPersonagem.text = nomesSequencia[2];
                        imagemPerfil.sprite = spritesSequencia[2];
                        break;
                    }
                case 3:
                    {
                        nomeDoPersonagem.text = nomesSequencia[3];
                        imagemPerfil.sprite = spritesSequencia[3];
                        break;
                    }

            }
        }

    }

    public void Personagem(Sprite imagemNPC, string[] texto, string nomePersonagem)
    {
        imagemPerfil.sprite = imagemNPC;
        textosDialogos = texto;
        nomeDoPersonagem.text = nomePersonagem;

        controleDeDialogos.SetActive(true);

        StartCoroutine(AnimacaoTexto());
    }

    public void PosPerguntas(Sprite[] imagemNPC, string[] texto, string[] nomePersonagem, int sequencia, bool opcao)
    {
        spritesSequencia = imagemNPC;
        textosDialogos = texto;
        nomesSequencia = nomePersonagem;

        Debug.Log($"{spritesSequencia[0].name}");

        sequenciaDeDialogos = sequencia;
        ativarOpcao = opcao;

        StartCoroutine(AnimacaoTexto());
    }

    IEnumerator AnimacaoTexto()
    {
        textoCompleto = false;
        conteudoTexto.text = "";
        foreach (char letras in textosDialogos[index].ToCharArray())
        {
            conteudoTexto.text += letras;
            yield return new WaitForSeconds(velocidadeTexto);
        }
        textoCompleto = true;
    }

    public void PularTexto()
    {
        if (!textoCompleto)
        {
            StopAllCoroutines();
            conteudoTexto.text = textosDialogos[index];
            textoCompleto = true;
        }
        //Verifica se ainda não foram passados todos os textos do diálogo
        else if (index < textosDialogos.Length - 1)
        {
            //Se ainda faltam textos, pula para o próximo, limpa o texto e inicia a animação do texto seguinte
            index++;
            fala++;
            if (ativarOpcao)
            {
                falaSequencia++;
            }

            StartCoroutine(AnimacaoTexto());
        }
        //Se todos os textos foram passados
        else
        {
            conteudoTexto.text = "";
            index = 0;
            falaSequencia = 0;
            //controleDeDialogos.SetActive(false);
        }
    }

}
