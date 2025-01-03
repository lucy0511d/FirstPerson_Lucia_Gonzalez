using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource Spotify;
    void Start()
    {
        
    }
    public void ReproducirSonido(AudioClip sonido)
    {
        //Ejecuta el clip introducido por par�metro de entrada
        Spotify.PlayOneShot(sonido);

    }

}
