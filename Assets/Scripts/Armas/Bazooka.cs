using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : MonoBehaviour
{
    [SerializeField] private GameObject grenadePrefab;
    [SerializeField] private Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Disparar();
    }
    private void Disparar()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(grenadePrefab, spawnPoint.position, spawnPoint.rotation);
            // Debug.Break(); -> Parar el juego cuando sucede la accion

        }
    }
}
