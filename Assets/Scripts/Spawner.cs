using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Spawnear cada 2 secs un zombie aleatorio entre distintos puntos de spawn
    [SerializeField] private Transform[] puntosSpawn;
    [SerializeField] private Enemigo enemigoPrefab;
    void Start()
    {
        Instantiate(enemigoPrefab, puntosSpawn[0].position, Quaternion.identity);
    }

    //IEnumerable SpawnerEnemigos()
    //{
    //  
    //}
  
}
