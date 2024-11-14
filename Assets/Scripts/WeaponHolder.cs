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

    private void CambiarArma(int nuevoIndice)
    {
        weapons[indiceArmaActual].SetActive(false);
        indiceArmaActual = nuevoIndice;
        weapons[indiceArmaActual].SetActive(true);
    }
}
