using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    private int perguntas = 1;
    
    private TabeladeAfinidades tabelaAfinidades;
    private ControleDialogos controleDialogos;
    private AtivarDesativarTexto ativarDesativarTexto;
    [SerializeField]
    private GameObject objetoDosTextos;

    public Sprite maya;
    public Sprite Ran;
    public Sprite Hanna;
    public Sprite Akira;
    public Sprite Fenwick;
    public Sprite Macula;
    public Sprite Cooper;
    public Sprite Disha;
    public Sprite Chefe;

    private string nomeDoPersonagemPrincipal;

    private void Start()
    {
        nomeDoPersonagemPrincipal = PlayerPrefs.GetString("nomeDoJogador");

        tabelaAfinidades = FindObjectOfType<TabeladeAfinidades>();
        controleDialogos = FindObjectOfType<ControleDialogos>();
        ativarDesativarTexto = objetoDosTextos.GetComponent<AtivarDesativarTexto>();

        Debug.Log($"Ran sprite: {Ran}");
    }
    public void CliqueOpcao1()
    {
        Resposta(perguntas, 1);
        perguntas++;
    }
    public void CliqueOpcao2()
    {
        Resposta(perguntas, 2);
        perguntas++;
    }
    public void CliqueOpcao3()
    {
        Resposta(perguntas, 3);
        perguntas++;
    }
    public void CliqueOpcao4()
    {
        Resposta(perguntas, 4);
        perguntas++;
    }
    public void CliqueOpcao5()
    {
        Resposta(perguntas, 5);
        perguntas++;
    }

    private void Resposta(int pergunta, int opcaoEscolhida)
    {
        switch (pergunta)
        {
            case 1:
                {
                    switch (opcaoEscolhida)
                    {
                        case 4: //Verdade
                            {
                                ativarDesativarTexto.AtivarAnimação1(-5, "Maya");
                                ativarDesativarTexto.AtivarAnimação2(-5, "Hanna");
                                ativarDesativarTexto.AtivarAnimação3(10, "Ren");

                                tabelaAfinidades.AtualizarAfinidadeMaya(-5);
                                tabelaAfinidades.AtualizarAfinidadeHanna(-5);
                                tabelaAfinidades.AtualizarAfinidadeRan(10);

                                controleDialogos.PularTexto();
                                controleDialogos.BotaoDePular.SetActive(true);

                                Sprite[] sprites = { Ran, Hanna, Akira, maya };
                                string[] stringsTextos = { "Surpresa seria se eles dormissem antes de você.",
                                    "Fala sério, seria melhor se você mentisse(revira os olhos), como que você consegue dormir, em um dia tão crucial?! Você era para sair 2 horas atrás, sabia? Está atrasado.",
                                    $"{nomeDoPersonagemPrincipal} incrível que logo você acordou com a nossa ligação, você dorme que nem uma pedra.",
                                    "Gente, podemos deixar essa discussão à caminho do local? Não podemos perder mais tempo." };
                                string[] stringsNomes = { "Ran", "Hanna", "Akira", "Maya" };
                                int sequencia = stringsTextos.Length;

                                controleDialogos.PosPerguntas(sprites, stringsTextos, stringsNomes, sequencia, true);

                                break;
                            }
                        case 5: //Mentir
                            {
                                ativarDesativarTexto.AtivarAnimação1(5, "Maya");
                                ativarDesativarTexto.AtivarAnimação2(5, "Hanna");
                                ativarDesativarTexto.AtivarAnimação3(-10, "Ren");

                                tabelaAfinidades.AtualizarAfinidadeMaya(5);
                                tabelaAfinidades.AtualizarAfinidadeHanna(5);
                                tabelaAfinidades.AtualizarAfinidadeRan(-10);

                                controleDialogos.PularTexto();
                                controleDialogos.BotaoDePular.SetActive(true);

                                Sprite[] sprites = { Ran, Hanna, Akira, maya };
                                string[] stringsTextos = { "Espero que sim, mesmo…", 
                                    "Pelo menos o atraso deve ter valido a pena para você, queridinho(a) da mamãe e do Papai.", 
                                    "É uma sensação muito boa, não é? Desobedecer, amo (ele dá um riso).", 
                                    "Podemos, por favor, ir?! às horas estão passando, não podemos perder muito tempo aqui." };
                                string[] stringsNomes = { "Ran", "Hanna", "Akira", "Maya" };
                                int sequencia = stringsTextos.Length;

                                controleDialogos.PosPerguntas(sprites, stringsTextos, stringsNomes, sequencia, true);
                                break;
                            }
                    }

                    break;
                }
            case 2:
                {
                    switch (opcaoEscolhida)
                    {
                        case 4:
                            {
                                tabelaAfinidades.AtualizarAfinidadeMaya(5);
                                tabelaAfinidades.AtualizarAfinidadeRan(5);
                                break;
                            }
                    }

                    break;
                }
        }

        controleDialogos.DuasOpcoes.SetActive(false);
    }
}
