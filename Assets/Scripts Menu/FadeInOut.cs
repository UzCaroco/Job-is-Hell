using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    public KeyCode tecla = KeyCode.Space; // Qual tecla deve ativar o fade (transição)?
    public float escalaVelocidade = 1f;
    public Color corFade = Color.black;
    // Em vez de usar Lerp ou Slerp, permitimos adaptabilidade com uma curva configurável
    public AnimationCurve curva = new AnimationCurve(new Keyframe(0, 1),
        new Keyframe(0.5f, 0.5f, -1.5f, -1.5f), new Keyframe(1, 0));
    public bool comecarEscurecido = false;

    private float opacidade = 0f;
    private Texture2D textura;
    private int direcao = 0;
    private float tempo = 0f;

    private void Start()
    {
        if (comecarEscurecido) opacidade = 1f; else opacidade = 0f;
        textura = new Texture2D(1, 1);
        textura.SetPixel(0, 0, new Color(corFade.r, corFade.g, corFade.b, opacidade));
        textura.Apply();
    }

    private void Update()
    {
        if (direcao == 0 && Input.GetKeyDown(tecla))
        {
            if (opacidade >= 1f) // Totalmente escurecido
            {
                opacidade = 1f;
                tempo = 0f;
                direcao = 1;
            }
            else // Totalmente visível
            {
                opacidade = 0f;
                tempo = 1f;
                direcao = -1;
            }
        }
    }

    public void OnGUI()
    {
        if (opacidade > 0f) GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), textura);
        if (direcao != 0)
        {
            tempo += direcao * Time.deltaTime * escalaVelocidade;
            opacidade = curva.Evaluate(tempo);
            textura.SetPixel(0, 0, new Color(corFade.r, corFade.g, corFade.b, opacidade));
            textura.Apply();
            if (opacidade <= 0f || opacidade >= 1f) direcao = 0;
        }
    }

}
