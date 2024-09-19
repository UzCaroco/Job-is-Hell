using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MuteUnmute : MonoBehaviour
{
    private bool mudeUnmute = true;

    [SerializeField] private AudioSource musicaFundo;

    [SerializeField] private Sprite somLigado;
    [SerializeField] private Sprite somDesligado;

    [SerializeField] private Image somImagem;

    

    public void LigarDesligarSom()
    {
        mudeUnmute = !mudeUnmute;
        musicaFundo.enabled = mudeUnmute;

        if (mudeUnmute)
        {
            somImagem.sprite = somLigado;
        }
        else
        {
            somImagem.sprite = somDesligado;
        }
    }

    public void SliderMusica(float valor)
    {
        musicaFundo.volume = valor;
    }
}
