using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject audioManager;
    public void EmpezarPartida()
    {
        //Time.timeScale = 0;
        //delay = contador;
        //if (delay == contador && Time.timeScale == 0)
        //{ 
        //    delay -= contador * Time.deltaTime;
        //
        //    if (delay <= 0)
        //    {
        //        
        //        SceneManager.LoadScene(1);
        //        delay = contador;
        //
        //    }
        //
        //}
        //Cargar Escena 1


        SceneManager.LoadScene(1);


    }
    public void SalirJuego()
    {
        Application.Quit();
    }
    public void PantallaMuerte()
    {
        SceneManager.LoadScene(2);
    }
    public void Respawn()
    {
        SceneManager.LoadScene(1);
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void Help()
    {
        SceneManager.LoadScene(4);
    }
    public void VolverAlInicio()
    {
        SceneManager.LoadScene(0);
    }
}
