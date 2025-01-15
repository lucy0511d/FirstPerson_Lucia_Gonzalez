using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioManager;

    private void Start()
    {

    }
    public void ReproducirSonidoMuerte(AudioClip sonidoMuerte)
    {
        //Ejecuta el clip introducido por parámetro de entrada
        audioManager.PlayOneShot(sonidoMuerte);

    }
    public void ReproducirSonidoSalto(AudioClip sonidoSalto)
    {
        //Ejecuta el clip introducido por parámetro de entrada
        audioManager.PlayOneShot(sonidoSalto);

    }

}
