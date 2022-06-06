using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public AudioSource clickBoton;
    public GameObject videos1;
    public GameObject videos2;
    public GameObject videos3;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;


    [SerializeField]
    private PlayerMove player;
    // Start is called before the first frame update
    void Start()
    {
        optionsPanel.SetActive(false);
        player = FindObjectOfType<PlayerMove>();
        videos1.SetActive(false);
        videos2.SetActive(false);
        videos3.SetActive(false);
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

    public void MostrarVideo1()
    {
        clickBoton.Play();
        videos2.SetActive(false);
        button2.SetActive(true);
        videos1.SetActive(true);
        button1.SetActive(false);
        videos3.SetActive(false);
        button3.SetActive(true);
    }

    public void MostrarVideo2()
    {
        clickBoton.Play();
        videos2.SetActive(true);
        videos1.SetActive(false);
        button1.SetActive(true);
        button2.SetActive(false);
        videos3.SetActive(false);
        button3.SetActive(true);
    }

    public void MostrarVideo3()
    {
        clickBoton.Play();
        videos2.SetActive(false);
        button2.SetActive(true);
        videos1.SetActive(false);
        button1.SetActive(true);
        videos3.SetActive(true);
        button3.SetActive(false);
    }

    public void Reiniciar()
    {
        player.Reset();
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
        player.musicaFondo.Pause();
        optionsPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void volver()
    {
        clickBoton.Play();
        player.musicaFondo.Play();
        optionsPanel.SetActive(false);
        Time.timeScale = 1;
    }

}
