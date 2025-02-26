using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] GameObject[] weapons;
    private int indicearmaActual = 1;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CambiarArmaConTeclado();
        CambiarArmaConRaton();

    }

    private void CambiarArmaConTeclado()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            CambioArma(0);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            CambioArma(1);

        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            CambioArma(2);

        }
        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            CambioArma(3);

        }
    }
    void CambiarArmaConRaton()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        Debug.Log(scrollWheel);
        if (scrollWheel > 0) //Anterior
        {
            CambioArma(indicearmaActual - 1);
        }
        else if (scrollWheel < 0)//siguiente  
        {
            CambioArma(indicearmaActual + 1);
        }
    }

    void CambioArma(int nuevoArma)
    {
        //desactivo el amra que actualmente llevo equipada

        if (nuevoArma < weapons.Length && nuevoArma >= 0)
        {
            weapons[indicearmaActual].SetActive(false);

            indicearmaActual = nuevoArma;

            weapons[indicearmaActual].SetActive(true);
        }
        //despues, cambio el indice

    }


}
