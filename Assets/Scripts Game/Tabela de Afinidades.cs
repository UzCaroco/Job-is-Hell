using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabeladeAfinidades : MonoBehaviour
{
    [SerializeField] private GameObject tabela;

    [Header ("Positivos")]
    [SerializeField] private Slider sliderFenwick;
    [SerializeField] private Slider sliderMacula;
    [SerializeField] private Slider sliderCooper;
    [SerializeField] private Slider sliderDisha;
    [SerializeField] private Slider sliderRan;
    [SerializeField] private Slider sliderHanna;
    [SerializeField] private Slider sliderAkira;
    [SerializeField] private Slider sliderMaya;
    [SerializeField] private Slider sliderChefe;

    [Header("Negativos")]
    [SerializeField] private Slider sliderFenwickNegativo;
    [SerializeField] private Slider sliderMaculaNegativo;
    [SerializeField] private Slider sliderCooperNegativo;
    [SerializeField] private Slider sliderDishaNegativo;
    [SerializeField] private Slider sliderRanNegativo;
    [SerializeField] private Slider sliderHannaNegativo;
    [SerializeField] private Slider sliderAkiraNegativo;
    [SerializeField] private Slider sliderMayaNegativo;
    [SerializeField] private Slider sliderChefeNegativo;

    private bool ativarDesativar = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ativarDesativar = !ativarDesativar;
            tabela.SetActive(ativarDesativar);
        }
    }

    // Função para atualizar a afinidade
    public void AtualizarAfinidadeFenwick(int novaAfinidade)
    {
        float _novaAfinidade = novaAfinidade;
        CalcularAfinidade(sliderFenwick, sliderFenwickNegativo, _novaAfinidade);
    }
    public void AtualizarAfinidadeMacula(int novaAfinidade)
    {
        float _novaAfinidade = novaAfinidade;
        CalcularAfinidade(sliderMacula, sliderMaculaNegativo, _novaAfinidade);
    }
    public void AtualizarAfinidadeCooper(int novaAfinidade)
    {
        float _novaAfinidade = novaAfinidade;
        CalcularAfinidade(sliderCooper, sliderCooperNegativo, _novaAfinidade);
    }
    public void AtualizarAfinidadeDisha(int novaAfinidade)
    {
        float _novaAfinidade = novaAfinidade;
        CalcularAfinidade(sliderDisha, sliderDishaNegativo, _novaAfinidade);
    }
    public void AtualizarAfinidadeRan(int novaAfinidade)
    {
        float _novaAfinidade = novaAfinidade;
        CalcularAfinidade(sliderRan, sliderRanNegativo, _novaAfinidade);
    }
    public void AtualizarAfinidadeHanna(int novaAfinidade)
    {
        float _novaAfinidade = novaAfinidade;
        CalcularAfinidade(sliderHanna, sliderHannaNegativo, _novaAfinidade);
    }
    public void AtualizarAfinidadeAkira(int novaAfinidade)
    {
        float _novaAfinidade = novaAfinidade;
        CalcularAfinidade(sliderAkira, sliderAkiraNegativo, _novaAfinidade);
    }
    public void AtualizarAfinidadeMaya(int novaAfinidade)
    {
        float _novaAfinidade = novaAfinidade;
        CalcularAfinidade(sliderMaya, sliderMayaNegativo, _novaAfinidade);
    }
    public void AtualizarAfinidadeChefe(int novaAfinidade)
    {
        float _novaAfinidade = novaAfinidade;
        CalcularAfinidade(sliderChefe, sliderChefeNegativo, _novaAfinidade);
    }

    public void CalcularAfinidade(Slider positivo, Slider negativo, float valor)
    {
        float calculo = (positivo.value + negativo.value) + valor;

        if (calculo >= 0)
        {
            negativo.value = 0f;
            positivo.value = calculo;
        }
        else if (calculo < 0)
        {
            positivo.value = 0f;
            negativo.value = -calculo;
        }
    }
}
