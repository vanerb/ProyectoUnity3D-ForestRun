using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject optionsPanel; 
    public AudioSource clickBoton;
    // Start is called before the first frame update
    void Start()
    {
        optionsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Creditos()
    {
        clickBoton.Play();
        Time.timeScale = 1;
        SceneManager.LoadScene("Creditos");

    }

    public void Reiniciar()
    {
       
        clickBoton.Play();
        SceneManager.LoadScene("SampleScene");
    }

    public void Reiniciar2()
    {

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
        clickBoton.Play();
        SceneManager.LoadScene("MenuPrincipal");
        Time.timeScale = 1;
    }

    public void ComoJugar()
    {
        clickBoton.Play();
        SceneManager.LoadScene("ComoJugar");
    }

    public void Pause()
    {
        clickBoton.Play();
        
        optionsPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void volver()
    {
        clickBoton.Play();
        
        optionsPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
