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
        StartCoroutine(SpawnerEnemigos());
    }

    private IEnumerator SpawnerEnemigos()
    {
        while (true)
        {
            Enemigo copia = Instantiate(enemigoPrefab, puntosSpawn[Random.Range(0, puntosSpawn.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
       
    }
    void SpawnearObjeto() //Opcional
    {
        float rng = Random.Range(0f, 1f);
        if(rng <= 0.2f) //20%
        {

        }
        else if (rng <= 0.3f) //10%
        {

        }
        else if (rng <= 0.45f) //15%
        {

        }
    }
  
}
