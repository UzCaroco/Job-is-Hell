using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AtivarDesativarTexto : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI texto1;
    [SerializeField] private TextMeshProUGUI texto2;
    [SerializeField] private TextMeshProUGUI texto3;

    public void AtivarAnimação1(int valor, string personagem)
    {
        VerificarCorEAtivar(valor, texto1, personagem);
    }
    public void AtivarAnimação2(int valor, string personagem)
    {
        VerificarCorEAtivar(valor, texto2, personagem);
    }
    public void AtivarAnimação3(int valor, string personagem)
    {
        VerificarCorEAtivar(valor, texto3, personagem);
    }
    public void DesativarAnimação1()
    {
        texto1.gameObject.SetActive(false);
    }
    public void DesativarAnimação2()
    {
        texto2.gameObject.SetActive(false);
    }
    public void DesativarAnimação3()
    {
        texto3.gameObject.SetActive(false);
    }

    private void VerificarCorEAtivar(int valor, TextMeshProUGUI texto, string personagem)
    {
        if (valor > 0)
        {
            texto.color = new Color(0f, 0.5f, 0f, 0.7f);
            texto.text = $"{personagem} + {valor}";
        }
        else
        {
            texto.color = new Color(0.7f, 0f, 0f, 0.7f);
            texto.text = $"{personagem} {valor}";
        }

        texto.gameObject.SetActive(true);
    }
}
