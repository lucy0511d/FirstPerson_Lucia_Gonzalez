using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;
    int indiceArmaActual = -1;
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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CambiarArma(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CambiarArma(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CambiarArma(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CambiarArma(3);
        }
    }
    private void CambiarArmaConRaton()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel > 0) //Anterior
        {
            CambiarArma(indiceArmaActual - 1);
        }
        else if (scrollWheel < 0) //Siguiente
        {
            CambiarArma(indiceArmaActual + 1);
        }
    }

    private void CambiarArma(int nuevoIndice)
    {
        
        if (nuevoIndice >= 0 && nuevoIndice < weapons.Length)
        {
            weapons[indiceArmaActual].SetActive(false);
            indiceArmaActual = nuevoIndice;
            weapons[indiceArmaActual].SetActive(true);
        }
    }
}
