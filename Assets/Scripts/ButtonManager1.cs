using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager1 : MonoBehaviour
{
    public AudioSource clickBoton;
    public void Creditos()
    {
        clickBoton.Play();
        Time.timeScale = 1;
        SceneManager.LoadScene("Creditos");

    }

    public void Reiniciar()
    {
        PlayerMove.contador = 0;
        clickBoton.Play();
        SceneManager.LoadScene("SampleScene");
    }

    public void Reiniciar2()
    {
        PlayerMove.contador = 0;
        clickBoton.Play();
        SceneManager.LoadScene("SampleScene");
    }

    public void Salir()
    {
        clickBoton.Play();
        Application.Quit();
    }

    public void MenuPrincipal()
    {
        PlayerMove.contador = 0;
        clickBoton.Play();
        SceneManager.LoadScene("MenuPrincipal");
        Time.timeScale = 1;
    }

    public void ComoJugar()
    {
        clickBoton.Play();
        SceneManager.LoadScene("ComoJugar");
    }

  

  
}
